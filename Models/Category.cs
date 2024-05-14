
using Dapper.Contrib.Extensions;

namespace Blog.Models{
    [Table("[Category]")]
    public class Category{
        public string Id { get; set;}
        public string Name { get; set;}
        public string Slug { get; set;}
    }
}