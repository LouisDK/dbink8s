using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {

           return $"Version 2 working at {DateTime.Now.ToString("dd MMM yyyyy HH:mm:ss")}";
        }

    }
}
