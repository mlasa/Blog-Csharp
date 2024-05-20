using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens{
    public static class DeleteUserScreen{
        public static void Load(){
            Console.WriteLine("Qual usuário deseja deletar? Digite o id");
            var userId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Procurando...");
            var user = FindTag(userId);
            if (user == null) {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("Nenhum usuário encontrado");
                Console.ForegroundColor = ConsoleColor.Gray; 
                UserMenuScreen.Load();
            }
            else{
                Console.WriteLine($"Confirme: {user.Name} | Id: {user.Id}? \nDigite s ou n");
                var response = Console.ReadLine()!;

                if(response == "s") {
                    Delete(userId);
                }
            }

            Console.WriteLine("");
            UserMenuScreen.Load();
        }

        public static void Delete(int id){
            Console.ForegroundColor = ConsoleColor.Blue;            
            var repository = new Repository<User>();
            repository.Delete(id);
            Console.WriteLine("Usuário deletado");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static User FindTag(int id){
            var repository = new Repository<User>();
            return repository.Get(id);
        }
    }
}