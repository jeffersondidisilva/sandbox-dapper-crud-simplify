using System;

namespace Sandbox.Dapper.Crud.Simplify.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsUpdate{ get; set; } //Not persisted, only for aux property example 
    }
}