using ProductManager.Domain.Common;
using ProductManager.Domain.ValueObjects.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductManager.Domain.Entities
{
    public class Category : BaseEntity
    {
        public CategoryName Name { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category(CategoryName name) 
        {
            Name =name;
        }
        public Category() 
        {
        
        }

        public static Category Create(string name) => new Category { Name = CategoryName.Create(name) };
    }
}
