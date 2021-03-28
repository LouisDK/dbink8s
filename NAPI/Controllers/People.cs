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


            x.Add(new Person() { personID = -1, firstName = $"v8", age = 2 });


            return x;
        }

        [HttpPost]
        public void Add(Person newPerson)
        {
            DAL.AddPerson(newPerson.firstName).GetAwaiter().GetResult();
        }

        //public class Person
        //{
        //    public string Name { get; set; }
        //}

    }
}
