﻿using System;
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
            char[] Quality  = { 'A','B', 'C', 'D', 'E'};
            Random random = new Random();
            int index = random.Next(Quality.Length);
            var S3 = $"{Quality[index]}";
            return S3.ToString(); 
        }
    }
}
