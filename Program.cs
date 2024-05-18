using System;
using Blog.Screens.TagScreens;
using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog;

class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=root@mlasa00;Trusted_Connection=False; TrustServerCertificate=True;";
    static void Main(string[] args)
    {
        Console.Clear();
        Database.Connection = new SqlConnection(CONNECTION_STRING);
        Database.Connection.Open();
        Load();
        Database.Connection.Close();
        Console.ReadKey();
    }

    public static void Load(){
        Console.WriteLine("1 - Gestão de usuário [🚧 em construcao]");
        Console.WriteLine("2 - Gestão de perfil [🚧 em construcao]");
        Console.WriteLine("3 - Gestão de categoria [🚧 em construcao]");
        Console.WriteLine("4 - Gestão de tag");
        Console.WriteLine("5 - Vincular perfil/usuário [🚧 em construcao]");
        Console.WriteLine("6 - Vincular post/tag [🚧 em construcao]");
        Console.WriteLine("7 - Relatórios [🚧 em construcao]");
        Console.WriteLine("\n");
        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 4:
                MenuTagScreen.Load();
                break;
            default: Load(); break;
        }
    }
}
