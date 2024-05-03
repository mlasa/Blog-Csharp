using System;
using System.Linq;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog;

class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=root@mlasa00;Trusted_Connection=False; TrustServerCertificate=True;";
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        ReadUsers();
    }

    public static void ReadUsers(){

        using(var connection = new SqlConnection(CONNECTION_STRING)){
            var users = connection.GetAll<User>();

            Console.WriteLine($"Registros encontrados: {users.Count()}");

            foreach(var user in users){
                Console.WriteLine($"* {user.Name}");
            }
        }
    }
}
