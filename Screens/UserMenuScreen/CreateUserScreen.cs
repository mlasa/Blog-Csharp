using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens{
    public static class CreateUserScreen{
        public static void Load(){
            Console.WriteLine("********** Cadastro de usuário **********");
            Console.WriteLine("Nome?");
            var name = Console.ReadLine()!;
            Console.WriteLine("E-mail?");
            var email = Console.ReadLine()!;
            Console.WriteLine("Senha?");
            var pass = Console.ReadLine()!;
            Console.WriteLine("Slug?");
            var slug = Console.ReadLine()!;
            Console.WriteLine("Bio (breve descricao)?");
            var bio = Console.ReadLine()!;
            Console.WriteLine("Caminho da imagem?");
            var image = Console.ReadLine()!;

            try{
                var user = new User ( name, email, pass, bio, slug, image );
                Create(user);
            }
            catch(Exception err){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não foi possível cadastrar o usuário");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            UserMenuScreen.Load();
        }

        public static void Create(User user){
            var repository = new Repository<User>();
            repository.Create(user);
            Console.WriteLine("Usuário criado");
        }
    }
}