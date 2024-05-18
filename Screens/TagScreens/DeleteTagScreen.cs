using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens{
    public static class DeleteTagScreen{
        public static void Load(){
            Console.WriteLine("Qual Id da tag que deseja deletar?");
            var tagId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Procurando...");
            var tag = FindTag(tagId);
            if (tag == null) {
                Console.WriteLine("Nada foi encontrado");
                MenuTagScreen.Load();
            }
            else{
                Console.WriteLine($"Confirme: {tag.Name} | Id: {tag.Id}? \nDigite s ou n");
                var response = Console.ReadLine()!;

                if(response == "s") {
                    Delete(tagId);
                }
            }

            Console.WriteLine("");
            MenuTagScreen.Load();
        }

        public static void Delete(int id){
            Console.ForegroundColor = ConsoleColor.Blue;            
            var repository = new Repository<Tag>();
            repository.Delete(id);
            Console.WriteLine("Tag deletada");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static Tag FindTag(int id){
            var repository = new Repository<Tag>();
            return repository.Get(id);
        }
    }
}