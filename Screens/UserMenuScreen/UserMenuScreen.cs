using System;

namespace Blog.Screens.UserScreens{
    public static class UserMenuScreen{
        public static void Load(){
            Console.WriteLine("**** Gestão de Usuários ****");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Listar todos usuários");
            Console.WriteLine("3- Buscar usuário");
            Console.WriteLine("4 - Cadastrar usuário");
            Console.WriteLine("5 - Deletar usuário");
            Console.WriteLine("6 - Adicionar perfil a um usuário");

            var option = short.Parse(Console.ReadLine()!);
            Console.WriteLine("\n");

            switch(option){
                case 1:  
                    ListUserScreen.Load(); 
                    break;
                case 6:  
                    AddRoleToUser.Load(); 
                    break;
                default:
                    Load(); 
                    break;
            }
        }
    }
}