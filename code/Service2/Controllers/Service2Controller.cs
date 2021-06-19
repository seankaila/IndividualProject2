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
        {
            string[] answers = new string[] { "It is decidedly so.", "Without a doubt", "Yes definitely", "You may rely on it", "Better not tell you now.", "Outlook not so good", "Hell no", "Never going to happen"};
            Random random = new Random();
            int index = random.Next(answers.Length);
            var S2 = $"{answers[index]}";
            return S2.ToString();
        }
    }
}
