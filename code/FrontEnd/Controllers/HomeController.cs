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

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration;
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            //var service4 = "https://localhost:44377/service4";
            var service4 = $"{Configuration["Service4URL"]}/service4";
            //string testC4 = Configuration.GetSection("Service4URL").Value;

            //var service4 = testC4 + "/service4";

            var Service4ResponceCall = await new HttpClient().GetStringAsync(service4);
            ViewBag.responceCall = Service4ResponceCall;
            return View();
        }
    }
}
