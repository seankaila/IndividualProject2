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
        {
            var S3 = "little";
            return S3.ToString();
        }
    }
}
