using System;
using Blog.Models;
using Blog.Repositories;
namespace Blog.Screens.UserScreens{
    public static class FindUserScreen{
        public static void Load(){
            Console.WriteLine("************* Buscar usuário ************");
            Console.WriteLine("Qual Id do usuário?");
            var userId = int.Parse(Console.ReadLine()!);
            if(userId == 0) {
                Load();
                return;
            }
            var user = FindUser(userId);
            if(user == null){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Usuário não encontrado");
                Console.ForegroundColor = ConsoleColor.Gray;
                Load();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{user.Id} | {user.Name} | {user.Email}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Program.Load();
        }

        private static User FindUser(int userId){
            var repository = new Repository<User>();
            return repository.Get(userId);
        }
    }
}