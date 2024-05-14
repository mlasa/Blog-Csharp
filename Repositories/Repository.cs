using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories{
    public class Repository<T> where T : class{
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection) =>  _connection = connection;

        public IEnumerable<T> Get() => _connection.GetAll<T>();
        public T Get(int id) => _connection.Get<T>(id);
        
         public void Create(T t)  => _connection.Insert<T>(t);
        public void Delete(T t) => _connection.Delete<T>(t);
        public void Delete(int id) {
            if(id!= 0) return;
            
            var t = _connection.Get<T>(id);
             _connection.Delete<T>(t);
        }
        public void Update(T t) => _connection.Update<T>(t);
    }
}