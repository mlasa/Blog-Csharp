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
            Id= 8,
            Name = "Vim",
            Bio = "Se inspira muito nos terminais",
            Email = "v@gmail.com",
            Image = "v.jpg",
            PasswordHash = "HASH",
            Slug = "v-term"
        };

        Console.WriteLine("Projeto: Blog\n----------------------\n\n");
        //CreateUser(user, connection);
        DeleteUser(user, connection);
        ReadUsers(connection);
        //ReadRoles(connection);
        connection.Close();
    }

    public static void ReadUsers(SqlConnection connection){
        var repository = new Repository<User>(connection);
        var users = repository.Get();
        
        foreach (var user in users) {
            Console.WriteLine("* " + user.Name + user.Roles.Count);
            foreach(var role in user.Roles) Console.WriteLine("- oba" + role.Name);
        }
    }
    public static void DeleteUser(User user, SqlConnection connection) {
                var repository = new Repository<User>(connection);
            repository.Delete(user);
    }
    public static void CreateUser(User user, SqlConnection connection){
        var repository = new Repository<User>(connection);
        repository.Create(user);
    }
    public static void ReadRoles(SqlConnection connection){
        var repository = new Repository<Role>(connection);
        var roles = repository.Get();
        
        Console.WriteLine($"Roles:\n");
        foreach (var rol in roles) Console.WriteLine("* " + rol.Name);
    }
}
