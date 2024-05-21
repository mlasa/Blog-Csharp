using System;
using System.Linq;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens{
    public static class ListTagScreen{
        public static void Load(){
            Console.WriteLine("Listando tags...");
            List();
            Console.WriteLine("");
            MenuTagScreen.Load();
        }

        public static void List(){
            Console.ForegroundColor = ConsoleColor.Blue;

            var repository = new Repository<Tag>();
            var tags = repository.Get();
            Console.WriteLine($"{tags.Count()} registros encontrados");
            foreach (var tag in tags){
                Console.WriteLine($" - {tag.Id} | {tag.Name}");
            }
            
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}