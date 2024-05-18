using System;

namespace Blog.Screens.TagScreens{
    public static class MenuTagScreen{
        public static void Load(){
            Console.WriteLine("**** Gestão de Tags ****");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Listas tags");
            Console.WriteLine("2 - Cadastrar tag");
            Console.WriteLine("3 - Deletar tag");
            var option = short.Parse(Console.ReadLine()!);
            Console.WriteLine("\n");

            switch(option){
                case 1:  
                    ListTagScreen.Load(); 
                    break;
                case 2: 
                    CreateTagScreen.Load(); 
                    break;
                case 3: 
                    DeleteTagScreen.Load(); 
                    break;
                default:
                    Load(); 
                    break;
            }
        }
    }
}