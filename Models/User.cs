using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Blog.Models{
    [Table("[User]")]
    public class User{

        public User(string name, string email, string password, string bio, string slug, string image) {
            Roles = new List<Role>();
            Name = name;
            Email = email;
            PasswordHash = password;
            Bio = bio;
            Image = image;
            Slug = slug;
        }

        //Construtor sem parâmetros
        //System.InvalidOperationException: A parameterless default constructor or one matching signature
        public User()
        {
            Roles = new List<Role>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        [Write(false)] //Quando fizermos insert de usuário não queremos inserir roles
        public List<Role> Roles { get; set; }   
    }
}