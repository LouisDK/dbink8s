using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class People : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var x = DAL.GetListOfPeople().GetAwaiter().GetResult();

            if (x.Count > 1)
            {
                x.First().firstName += $" - {Environment.MachineName}";
            }

            return x;
        }

    }
}
