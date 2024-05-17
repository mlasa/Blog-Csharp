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
            //Id= 8,
            Name = "Fanuel Vander",
            Bio = "Enfermeiro muito querido pelos pacientes",
            Email = "fanuel@email.com",
            Image = "fanu.jpg",
            PasswordHash = "HASH",
            Slug = "fanuelvander"
        };

        Console.Clear();
        Console.WriteLine("Projeto: Blog\n----------------------\n\n");
        //CreateUser(user, connection);
        //DeleteUser(user, connection);
        ReadUsersWithRoles(connection);
        //ReadRoles(connection);
        connection.Close();
    }

    public static void ReadUsersWithRoles(SqlConnection connection){
        var repository = new UserRepository(connection);
        var users = repository.GetUsersWithRoles();
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
