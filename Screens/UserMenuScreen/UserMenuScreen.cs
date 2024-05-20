using System;

namespace Blog.Screens.UserScreens{
    public static class UserMenuScreen{
        public static void Load(){
            Console.WriteLine("**** Gestão de Usuários ****");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Listar todos usuários");
            Console.WriteLine("2- Buscar usuário");
            Console.WriteLine("3 - Cadastrar usuário");
            Console.WriteLine("4 - Deletar usuário");
            Console.WriteLine("5 - Adicionar perfil a um usuário");

            var option = short.Parse(Console.ReadLine()!);
            Console.WriteLine("\n");

            switch(option){
                case 0:  
                    Program.Load(); 
                    break;
                case 1:  
                    ListUserScreen.Load(); 
                    break;
                case 2:  
                    FindUserScreen.Load(); 
                    break;
                case 3:  
                    CreateUserScreen.Load(); 
                    break;
                case 4:  
                    DeleteUserScreen.Load(); 
                    break;
                case 5:  
                    AddRoleToUser.Load(); 
                    break;
                default:
                    Load(); 
                    break;
            }
        }
    }
}