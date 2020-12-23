using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dommel;
using Sandbox.Dapper.Crud.Simplify.Models.Common;
using Sandbox.Dapper.Crud.Simplify.Properties;

namespace Sandbox.Dapper.Crud.Simplify.Repositories.Common
{
    public abstract class BaseRepository<TEntity> where TEntity : EntityBase, new()
    {
        private readonly SqlConnection _connection;

        protected BaseRepository()
        {
            _connection =  new SqlConnection(ConnectionString.Value);
        }
        
        public async Task<IList<TEntity>> GetAllAsync() => 
            (await _connection.GetAllAsync<TEntity>()).ToList();

        public async Task<TEntity> GetByIdAsync(Guid id) => 
            await _connection.GetAsync<TEntity>(id);

        public async Task SaveAsync(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            await _connection.InsertAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity) => 
            await _connection.UpdateAsync(entity);
        
        public async Task DeleteAsync(Guid id) => 
            await _connection.DeleteAsync(new TEntity { Id = id });
    }
}