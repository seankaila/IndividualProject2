using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEnd.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FrontEnd.Interfaces;
using Microsoft.Extensions.Options;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        //public IConfiguration Configuration;
        private AppSettings Configuration;
        private IRepositoryWrapper repository;
        private HttpClient _client;
        public HomeController(HttpClient client, IOptions<AppSettings> settings, IRepositoryWrapper repositoryWrapper)
        {
            _client = client ?? new HttpClient();
            Configuration = settings.Value;
            repository = repositoryWrapper;
        } //dependency injection for appsettings, httpclient and repositorywrapper.


        public IActionResult Index()
        {
            return View();
        } //simply returns a home view.

        [Route("AnswerPage")]
        public async Task<IActionResult> AnswerPage(string question)
        { //this function takes in a question aksed by the user.
            if (question == null)
            { 
                //if null then the user is taken back to the home page to ask again.
                return RedirectToAction("Index");
            }
            //var service4 = "https://localhost:44377/service4";
            //var service4 = $"{Configuration["Service4URL"]}/service4";
            var service4 = $"{Configuration.Service4URL}/service4";
            //getting url from appsettings.json
            var Service4ResponceCall = await _client.GetStringAsync(service4);
            dynamic data = JsonConvert.DeserializeObject<object>(Service4ResponceCall);
            IDictionary<string, JToken> results = data; //converting the data so its readble and maualble.
            int counter = 0;
            var answer = ""; //delcaring variables for later use.
            var resultProbability = "";
            foreach (var result in results) //looping thorough the data so that we can get the values we need from json.
            { 
                counter = counter + 1;
                var value = result.Value;
                if (counter == 1)
                {
                    answer = (string)value;
                }
                else
                {
                    resultProbability = (string)value;
                }
            }
            ViewBag.responceCall1 = answer;
            ViewBag.responceCall2 = resultProbability;
            ViewBag.responceCall3 = question; //using viewbag to output the data to the front end.

            var historyValues = new History
            {
                Question = question,
                Answer = answer,
                Probability = resultProbability,
            }; //prepping the data to be saved to the database using a class called history.
            repository.Historys.Create(historyValues); 
            repository.Save(); //saving the data.
            return View(); //returning to the answerpage view
        }

        [Route("History")]
        public IActionResult History() //Displays all the records in the hsitory table. 
        {
            var history = repository.Historys.FinalALL(); //retriving all data fromt the database.
            return View(history);
        }
    }
}
