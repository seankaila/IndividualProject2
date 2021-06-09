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
            var S2 = "chicken";
            return S2.ToString();
        }
    }
}
