using Dapper;

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;

namespace Server.Data
{
    public class DapperDb
    {
        public static void Main(string[] args)
        {
            using var connection = new SqlConnection("Server=.;Database=DapperDB;Trusted_Connection=True");

            connection.Open();
        }
      
        public static string Login(SqlConnection connection, string username, string password)
        {
            var resultAsArray = connection.Query<User>($"select * from Users where UserName = '{username}'").ToArray();

            if (resultAsArray.Length==0)
            {
                return "User doesn't exist";
            }
            else
            {
                if (resultAsArray[0].Password != password)
                {
                    return "Wrong Password";
                }
            }

            return "Successfull login";
        }

    }
}
