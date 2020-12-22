using System;

namespace Sandbox.CrudDapper.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsUpdate{ get; set; } //Not persisted
    }
}