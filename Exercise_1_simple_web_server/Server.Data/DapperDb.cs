using Dapper;

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.WebSockets;

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

        public static string Register(SqlConnection connection, string username, string password)
        {
            var checkIfUsernameAlreadyExist = connection.Query<User>($"select * from Users where UserName = '{username}'").ToArray();
            
            if (checkIfUsernameAlreadyExist.Length != 0)
            {
                return "Username is not available";
            }
            else
            {
                var insertQuery = $@"INSERT INTO Users (UserName, Password) VALUES (@username,@password)";
                var newUser = new User() { Username = username, Password = password };
                var success = connection.Execute(insertQuery, newUser);

                if (success==1)
                {
                    return "User successfully created";
                }
                else
                {
                    return "Unexpected error ocurred - please try again";
                }
            }
        }

    }
}
