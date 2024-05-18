using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens{
    public static class CreateTagScreen{
        public static void Load(){
            Console.WriteLine("Qual será o nome da tag?");
            var tagName = Console.ReadLine()!;
            Console.WriteLine("Qual será o slug da tag?");
            var tagSlug = Console.ReadLine()!;


            var newTag = new Tag();
            newTag.Name = tagName;
            newTag.Slug = tagSlug;

            Create(newTag);
        }
        public static void Create(Tag tag){
            var repository = new Repository<Tag>();
            repository.Create(tag);
            Console.WriteLine("Tag criada");            
            Console.WriteLine("");

            MenuTagScreen.Load();
        }
    }
}