using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens{
    public class ListUserScreen{
        public static void Load(){
            Console.WriteLine("Listando todos os usuários...");
            List();
            Console.WriteLine("");
            Program.Load();
        }

        public static void List(){
            Console.ForegroundColor = ConsoleColor.Blue;

            var repository = new UserRepository();
            var users = repository.GetUsersWithRoles();
            foreach (var user in users){
                Console.WriteLine($" * {user.Id}  {user.Name} | {user.Email}| {string.Join(", ", user.Roles.Select(role => role.Name))}");
            }
            
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}