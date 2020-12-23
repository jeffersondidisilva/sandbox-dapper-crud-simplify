using Sandbox.Dapper.Crud.Simplify.Models.Common;

namespace Sandbox.Dapper.Crud.Simplify.Models
{
    public class Category: EntityBase
    {
        public string Name { get; set; }
        public bool IsUpdate{ get; set; } //Not persisted, only for aux property example 
    }
}