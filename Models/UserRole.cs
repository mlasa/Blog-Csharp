using Dapper.Contrib.Extensions;

namespace Blog.Models{
    [Table("[UserRole]")]
    public class UserRole{
        public UserRole(int userId, int roleId){
            UserId = userId;
            RoleId = roleId;
        }
        public int UserId { get; set;}
        public int RoleId { get; set;}
    }
}