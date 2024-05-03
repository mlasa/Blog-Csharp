using System;
using System.Linq;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog;

class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=root@mlasa00;Trusted_Connection=False; TrustServerCertificate=True;";
    static void Main(string[] args)
    {
        var  connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();

        var user = new User(){
            Id = 4,
            Name = "Vim",
            Bio = "Se inspira muito nos terminais",
            Email = "v@gmail.com",
            Image = "v.jpg",
            PasswordHash = "HASH",
            Slug = "v-term"
        };

        Console.WriteLine("Projeto: Blog\n----------------------\n\n");
        //ReadUser(1,connection);
        //CreateUser(user,connection);
        //UpdateUser(user,connection);
        //DeleteUser(user,connection);
        ReadUsers(connection);

        connection.Close();
    }

    public static void ReadUsers(SqlConnection connection){
        var repository = new UserRepository(connection);
        var users = repository.Get();
        
        foreach (var user in users) Console.WriteLine("* " + user.Name);
    }

    public static void ReadUser(int id, SqlConnection connection){
        var repository = new UserRepository(connection);
        repository.Get(id);
    }

    public static void UpdateUser(User user, SqlConnection connection){
        var repository = new UserRepository(connection);
        repository.Update(user);
    }

    public static void DeleteUser(User user, SqlConnection connection){
        var repository = new UserRepository(connection);
        repository.Delete(user);
    }

    public static void CreateUser(User user, SqlConnection connection){
        var repository = new UserRepository(connection);
        repository.Create(user);
    }
}
