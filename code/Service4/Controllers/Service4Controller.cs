﻿using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
namespace Service4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Service4Controller : ControllerBase
    {
        //service 2 https://localhost:44384/
        //service 3  https://localhost:44393/
        public AppSettings Configuration;
        private HttpClient _client;
        public Service4Controller(HttpClient client, IOptions<AppSettings> settings)
        {
            _client = client ?? new HttpClient();
            Configuration = settings.Value;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var service2 = "https://localhost:44384/service2";
            //var service3 = "https://localhost:44393/service3";

            //var service2 = $"{Configuration["Service2URL"]}/service2";
            //var service3 = $"{Configuration["Service3URL"]}/service3";


            var service2 = $"{Configuration.Service2URL}/service2";
            var service3 = $"{Configuration.Service3URL}/service3";

            var Service2ResponceCall = await _client.GetStringAsync(service2);
            var Service3ResponceCall = await _client.GetStringAsync(service3);


            var Service4 = $"{Service3ResponceCall}: {Service2ResponceCall}";
            var resultProbability = probability(Service3ResponceCall);

            return Ok(new {Service4, resultProbability});
        }

        [NonAction]
        public int probability(string Service3ResponceCall)
        {
            int resultProbability = 0;
            switch (Service3ResponceCall)
            {
                case "A":
                    resultProbability = 100;
                    break;
                case "B":
                    resultProbability = 80;
                    break;
                case "C":
                    resultProbability = 60;
                    break;
                case "D":
                    resultProbability = 40;
                    break;
                case "E":
                    resultProbability = 20;
                    break;
                default:
                    resultProbability  = 404;
                    break;
            }
            return resultProbability;
        }
    }
}
