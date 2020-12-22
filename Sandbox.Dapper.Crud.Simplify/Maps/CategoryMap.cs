using System.ComponentModel.DataAnnotations.Schema;
using Dapper.FluentMap.Dommel.Mapping;
using Sandbox.Dapper.Crud.Simplify.Models;

namespace Sandbox.Dapper.Crud.Simplify.Maps
{
    public class CategoryMap: DommelEntityMap<Category>
    {
        public CategoryMap()
        {
            ToTable("Category");
            Map(e => e.Id).SetGeneratedOption(DatabaseGeneratedOption.None);
            Map(e => e.IsUpdate).Ignore();
        }
    }
}