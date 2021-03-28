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
            return DAL.GetListOfPeople().GetAwaiter().GetResult();
        }

        [HttpPost]
        public void Add(Person newPerson)
        {
            DAL.AddPerson(newPerson.firstName).GetAwaiter().GetResult();
        }

    }
}
