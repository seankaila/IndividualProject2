using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Service3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Service3Controller : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        { //This function creates an array of characters. and generates a random output based on the array.
            char[] Quality  = { 'A','B', 'C', 'D', 'E'};
            Random random = new Random();
            int index = random.Next(Quality.Length);  //using the random function to grab a random number from the array.
            var S3 = $"{Quality[index]}";  //grabbing the actual answer from the array using the random number
            return S3.ToString();  //returning the value as a string.
        }
    }
}
