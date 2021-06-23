using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Service2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Service2Controller : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        { //This function creates an array of answers. and generates a random output based on the array.
            string[] answers = new string[] {"It is Certain", "Without a doubt", "You may rely on it", "Most likely", "Don't count on it", "My reply is no", "My sources say no", "Very doubtful"}; 
            Random random = new Random(); 
            int index = random.Next(answers.Length); //using the random function to grab a random number from the array.
            var S2 = $"{answers[index]}"; //grabbing the actual answer from the array using the random number
            return S2.ToString(); //returning the value as a string.
        }
    }
}
