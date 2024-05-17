using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories{
    public class UserRepository:Repository<User>{
        private readonly SqlConnection _connection;
        public UserRepository(SqlConnection connection)
        :base(connection) =>  _connection = connection;

        public List<User> GetUsersWithRoles(){
            var sql = @"
                SELECT [User].*, [Role].*
                FROM [User]
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                LEFT JOIN [Role] ON [Role].[Id] = [UserRole].[RoleId]
            ";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                sql,
                (user, role) => 
                {
                    var usr = users.FirstOrDefault(x=> x.Id == user.Id);
                    if(usr == null){
                        usr = user;
                        if(role != null) usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else{
                        usr.Roles.Add(role);
                    }
                    return usr;
                },
                splitOn: "Id"
            );

           foreach (var user in users) {
            Console.WriteLine("* " + user.Name + " | Quantidade de perfis: " + user.Roles.Count);
            
            foreach(var role in user.Roles) Console.WriteLine("- " + role.Name);
        }

            return users;
        }
    }
}