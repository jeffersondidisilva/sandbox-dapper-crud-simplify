using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Sandbox.CrudDapper.Maps;
using Sandbox.CrudDapper.Models;
using Sandbox.CrudDapper.Repositories;

namespace Sandbox.CrudDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
            
            var repository = new CategorySimplifiedRepository();
            repository.SaveAsync(new Category { Name = "Cloud" } ).Wait();
        }

        private static void Start()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new CategoryMap());
                config.ForDommel();
            });
        }
    }
}