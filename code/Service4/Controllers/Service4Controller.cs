using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Service4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Service4Controller : ControllerBase
    {
        //service 2 https://localhost:44384/
        //service 3  https://localhost:44393/
        public IConfiguration Configuration;
        public Service4Controller(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var service2 = "https://localhost:44384/service2";
            //var service3 = "https://localhost:44393/service3";

            var service2 = $"{Configuration["Service2URL"]}/service2";
            var service3 = $"{Configuration["Service3URL"]}/service3";

            var Service2ResponceCall = await new HttpClient().GetStringAsync(service2);
            var Service3ResponceCall = await new HttpClient().GetStringAsync(service3);


            var Service4 = $"{Service2ResponceCall} {Service3ResponceCall}";
            var result = "chicken";

            return Ok(new {Service4, result});
        }
    }
}
