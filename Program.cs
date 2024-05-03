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
        DeleteUser(user);
        ReadUsers();
    }

    public static void ReadUsers(){

        using(var connection = new SqlConnection(CONNECTION_STRING)){
            var users = connection.GetAll<User>();

            Console.WriteLine($"Registros encontrados: {users.Count()}");

            foreach(var user in users){
                Console.WriteLine($"* {user.Id} | {user.Name} | {user.Email}");
            }
        }
    }

    public static void ReadUser(int id){

        using(var connection = new SqlConnection(CONNECTION_STRING)){
            var user = connection.Get<User>(id);
            Console.WriteLine($"* {user.Name}");
        }
    }

    public static void UpdateUser(User user){

        using(var connection = new SqlConnection(CONNECTION_STRING)){
            var rows = connection.Update<User>(user);
            if(rows) Console.WriteLine($"Usuário atualizado");
            else Console.WriteLine("Não foi possível atualizar o registro");
        }
    }

    public static void DeleteUser(User user){
        Console.WriteLine($"Usuário apagado");
        using(var connection = new SqlConnection(CONNECTION_STRING)){
            var rows = connection.Delete<User>(user);
            Console.WriteLine($"Usuário apagado");
        }
    }

    public static void CreateUser(User user){
        using(var connection = new SqlConnection(CONNECTION_STRING)){
            var newUser = connection.Insert<User>(user);
            Console.WriteLine("Cadastro realizado");
        }
    }
}
