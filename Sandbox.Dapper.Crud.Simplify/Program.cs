using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Sandbox.Dapper.Crud.Simplify.Maps;
using Sandbox.Dapper.Crud.Simplify.Models;
using Sandbox.Dapper.Crud.Simplify.Repositories;

namespace Sandbox.Dapper.Crud.Simplify
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