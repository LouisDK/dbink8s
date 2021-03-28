using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using NAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAPI.Controllers
{
    public class DAL
    {

        public static async Task<List<Person>> GetListOfPeople()
        {

            string sql = "SELECT * FROM People";
            using (var connection = Utils.DapperHelpers.GetConnection())
            {
                var ListOfPeople = await connection.QueryAsync<Person>(sql);
                return ListOfPeople.AsList();
            }

        }

        public static async Task AddPerson(string name)
        {
            var rnd = new Random();

            // Note the use of parameters. This is how to avoid SQL Injection attacks. https://www.learndapper.com/parameters
            string sql = "INSERT People (personID, firstName, age) VALUES (@personID, @firstName, @age)";
            var parameters = new { personID = rnd.Next(100,100000), firstName = name, age = rnd.Next(18,90)}; //Bad example, since we could have conflicts with PersonID numbers.

            //string sql = "INSERT People (personID, firstName, age, favColour) VALUES (@personID, @firstName, @age, @favColour)";
            //var parameters = new { personID = rnd.Next(100, 100000), firstName = name, age = rnd.Next(18, 90), favColour = "Yellow" }; //Bad example, since we could have conflicts with PersonID numbers.

            using (var connection = Utils.DapperHelpers.GetConnection())
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
