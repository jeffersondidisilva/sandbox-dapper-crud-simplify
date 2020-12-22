using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Sandbox.CrudDapper.Models;
using Sandbox.CrudDapper.Properties;

namespace Sandbox.CrudDapper.Repositories
{
    public class CategoryRepository
    {
        private readonly SqlConnection _connection;

        public CategoryRepository()
        {
            _connection = new SqlConnection(ConnectionString.Value);
        }
        
        public async Task<IList<Category>> GetAllAsync()
        {
            const string sql = "SELECT * FROM CATEGORY";
            return (await _connection.QueryAsync<Category>(sql)).ToList();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM CATEGORY WHERE Id = @Id";
            return (await _connection.QueryAsync<Category>(sql, new {id})).FirstOrDefault();
        }

        public async Task SaveAsync(Category category)
        {

            var sql = "UPDATE CATEGORY SET Name = @Name WHERE Id = @Id";
            
            if (!category.IsUpdate)
            {
                sql = "INSERT INTO CATEGORY VALUES(@Id, @Name)";
                category.Id = Guid.NewGuid();
            }
            
            await _connection.ExecuteAsync(sql, new {category.Id, category.Name});
        }
        
        public async Task DeleteAsync(Guid id)
        {
            const string sql = "DELETE CATEGORY WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new {id});
        }
    }
}