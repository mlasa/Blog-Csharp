using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens{
    public static class ListTagScreen{
        public static void Load(){
            Console.WriteLine("Listando tags...");
            List();
            Console.ReadKey();
        }

        public static void List(){
            var repository = new Repository<Tag>(Database.Connection);
            var tags = repository.Get();
            foreach (var tag in tags){
                Console.WriteLine($" - {tag.Name}");
            }
        }
    }
}