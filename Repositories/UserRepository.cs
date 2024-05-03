using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using Blog.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Blog.Repositories
{
    public class UserRepository
    {
        private SqlConnection _connection;
        public UserRepository(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
        
        public IEnumerable<User> Get() => _connection.GetAll<User>();
        public User Get(int id) => _connection.Get<User>(id);
        public void Create(User user) => _connection.Insert<User>(user);
        public void Delete(User user) => _connection.Delete<User>(user);
        public void Update(User user) => _connection.Update<User>(user);
    }
}