using ProductManager.Domain.Common;
using ProductManager.Domain.ValueObjects.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.Entities
{
    public class Category:BaseEntity
    {
        public CategoryName Name {  get; set; }
        public ICollection<Product> Products {  get; set; } 
    }
}
