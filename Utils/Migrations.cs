using Dapper;
using DbUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Migrations
    {

        public static void MakeDatabaseCurrent()
        {

            var TryCount = 0;
            while (TryCount < 10)
            {
                // Do a simple query to see if database is ready. A new instance of the database might need a few seconds before we can connect to it.
                if (IsDatabaseAvailableAsync().GetAwaiter().GetResult())
                {
                    TryCount = 1000; // Database Available
                }
                else
                {
                    TryCount += 1;
                    System.Threading.Thread.Sleep(1000);
                }
            }



            var upgradeEngine = DeployChanges.To.MySqlDatabase(DapperHelpers.GetConnectionString())
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();


            var result = upgradeEngine.PerformUpgrade();
            

            if (!result.Successful)
            {
                throw new Exception("Failed to upgrade database", result.Error);
            }
 

        }


        private static async Task<bool> IsDatabaseAvailableAsync()
        {
            try
            {
                string sql = "SELECT 2 + 5";
                using (var connection = Utils.DapperHelpers.GetConnection())
                {
                    var answer = await connection.QueryAsync<int>(sql);
                    if (answer.FirstOrDefault() == 7)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
          
        }

    }
}
