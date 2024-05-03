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
        //ReadUser(1);
        //CreateUser(user);
        //UpdateUser(user);
        //DeleteUser(user);
        ReadUsers();
    }

    public static void ReadUsers(){
        var repository = new UserRepository(CONNECTION_STRING);
        var users = repository.Get();
        
        foreach (var user in users) Console.WriteLine("* " + user.Name);
    }

    public static void ReadUser(int id){
        var repository = new UserRepository(CONNECTION_STRING);
        repository.Get(id);
    }

    public static void UpdateUser(User user){
        var repository = new UserRepository(CONNECTION_STRING);
        repository.Update(user);
    }

    public static void DeleteUser(User user){
        var repository = new UserRepository(CONNECTION_STRING);
        repository.Delete(user);
    }

    public static void CreateUser(User user){
        var repository = new UserRepository(CONNECTION_STRING);
        repository.Create(user);
    }
}
