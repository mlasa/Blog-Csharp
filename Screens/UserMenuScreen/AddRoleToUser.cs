using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens{
    public class AddRoleToUser(){
        public static void Load(){
            Console.WriteLine("A qual usuário quer adicionar um novo perfil? Digite o id:");
            var userId = int.Parse( Console.ReadLine()!.Trim());
            var user = GetUser(userId);
            if(user == null){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Usuário não encontrado");
                Console.ForegroundColor = ConsoleColor.Gray;
                UserMenuScreen.Load();
                return;
            }

            Console.WriteLine($"Buscando... \nConfirme:{userId} | {user.Name} |{user.Email}");
            Console.WriteLine("Digite s ou n");
            var userConfirmed = Console.ReadLine()!;

            if (userConfirmed == "s"){
                Console.WriteLine("Qual role vai ser adicionada ao usuário? Digite o id:");
                var roleId = int.Parse(Console.ReadLine()!.Trim());
                var role = GetRole(roleId);
                if(role == null){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Perfil não encontrado");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    UserMenuScreen.Load();
                    return;
                }
                Console.WriteLine($"Confirme: {role.Id} | {role.Name} \nDigite s ou n");
                var roleConfirm = Console.ReadLine()!;

                if(roleConfirm == "s"){
                    Console.WriteLine("Adicionando...");
                    AddRoleToProfile(userId,roleId);
                }
            }
            
            UserMenuScreen.Load();
        }
        public static void AddRoleToProfile(int userId, int roleId){
            var userRole = new UserRole(userId, roleId);
            var repository = new Repository<UserRole>();
            repository.Create(userRole);
        }
        private static User GetUser(int id){
            var repository = new Repository<User>();
            var user = repository.Get(id);
            return user;
        }
        private static Role GetRole(int id){
            var repository = new Repository<Role>();
            var role = repository.Get(id);
            return role;
        }
    }
}