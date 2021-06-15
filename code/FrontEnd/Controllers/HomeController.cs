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

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration;
        private IRepositoryWrapper repository;
        public HomeController(IConfiguration configuration, IRepositoryWrapper repositoryWrapper)
        {
            Configuration = configuration;
            repository = repositoryWrapper;
        }
        

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> AnswerPage(string question)
        {
            if (question == null)
            {
                return RedirectToAction("Index");
            }
            //var service4 = "https://localhost:44377/service4";
            var service4 = $"{Configuration["Service4URL"]}/service4";

            var Service4ResponceCall = await new HttpClient().GetStringAsync(service4);
            dynamic data = JsonConvert.DeserializeObject<object>(Service4ResponceCall);
            IDictionary<string, JToken> results = data;
            int counter = 0;
            var answer = "";
            var resultProbability = "";
            foreach (var result in results)
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
            ViewBag.responceCall3 = question;

            var historyValues = new History
            {
                Question = question,
                Answer = answer,
                Probability = resultProbability,
            };
            repository.Historys.Create(historyValues);
            repository.Save();
            return View();
        }
            [Route("History")]
        public IActionResult History() //Displays all the records in the Teams table. 
        {
            var history = repository.Historys.FinalALL();
            //var allTeams = dbContext.Teams.ToList();
            return View(history);
        }
    }
}
