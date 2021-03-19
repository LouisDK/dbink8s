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

    }
}
