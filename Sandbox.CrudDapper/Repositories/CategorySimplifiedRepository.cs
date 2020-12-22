using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dommel;
using Sandbox.CrudDapper.Models;
using Sandbox.CrudDapper.Properties;

namespace Sandbox.CrudDapper.Repositories
{
    public class CategorySimplifiedRepository
    {
        private readonly SqlConnection _connection;

        public CategorySimplifiedRepository()
        {
            _connection = new SqlConnection(ConnectionString.Value);
        }
        
        public async Task<IList<Category>> GetAllAsync() => 
            (await _connection.GetAllAsync<Category>()).ToList();

        public async Task<Category> GetByIdAsync(Guid id) => 
            await _connection.GetAsync<Category>(id);

        public async Task SaveAsync(Category category)
        {
            if (category.IsUpdate)
            {
                await _connection.UpdateAsync(category);
                return;
            }
            
            category.Id = Guid.NewGuid();
            await _connection.InsertAsync(category);
        }
        
        public async Task DeleteAsync(Guid id) => 
            await _connection.DeleteAsync(new Category { Id = id });
    }
}