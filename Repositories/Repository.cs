using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories{
    public class Repository<T> where T : class{
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection) =>  _connection = connection;

        public IEnumerable<T> Get() => Database.Connection.GetAll<T>();
        public T Get(int id) => Database.Connection.Get<T>(id);
        
         public void Create(T t)  => Database.Connection.Insert<T>(t);
        public void Delete(T t) => Database.Connection.Delete<T>(t);
        public void Delete(int id) {
            if(id!= 0) return;
            
            var t = Database.Connection.Get<T>(id);
             Database.Connection.Delete<T>(t);
        }
        public void Update(T t) => Database.Connection.Update<T>(t);
    }
}