using MySqlConnector;
using System;
using System.Threading;

namespace Utils
{
    public class DapperHelpers
    {

        private static string ConnStr = "";

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(ConnStr))
            {
                ConnStr = Environment.GetEnvironmentVariable("DBConnStr");
                if (string.IsNullOrEmpty(ConnStr))
                {
                    throw new Exception("Could not find DBConnStr environment variable.");
                }
                else
                {
                    return ConnStr;
                }
            }
            else
            {
                return ConnStr;
            }

            //var builder = new MySqlConnectionStringBuilder
            //{
            //    Server = "localhost",
            //    Port = 3306,
            //    Database = "ldk",
            //    UserID = "louis",
            //    Password = "ldk123",
            //    SslMode = MySqlSslMode.Preferred
            //};

            //return builder.ConnectionString;
        }



        public static MySqlConnection GetConnection()
        {

            string connectionString = GetConnectionString();
            var conn = new MySqlConnection(connectionString);

            conn.Open();

            DateTime endTime = DateTime.Now.AddSeconds(5);
            bool timeOut = false;

            while (conn.State == System.Data.ConnectionState.Connecting)
            {
                if (DateTime.Now.CompareTo(endTime) >= 0)
                {
                    timeOut = true;
                    break;
                }
                Thread.Yield(); //tells the kernel to give other threads some time
            }


            if (timeOut)
            {
                Console.WriteLine("Connection Timeout");
                throw new Exception("Connection timeout!");
            }

            return conn;
        }

    }
}
