using ProductManager.Domain.Common;
using ProductManager.Domain.ValueObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.Entities
{
    public class Product:BaseEntity
    {
        public ProductName Name { get; set; }
        public ProductPrice Price { get; set; } 
        public bool InStock { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }


        public Product (ProductName name, ProductPrice price,bool inStock, Guid categoryId,EntityStatus status= EntityStatus.Enabled)
        {
            Name= name; 
            Price = price; 
            InStock= inStock; 
            CategoryId= categoryId;
            Status = status;
        }
        public Product()
        {

        }
        public static Product Create(string name, decimal price, bool inStock, Guid categoryId,EntityStatus status)
        {
            return
                new Product
                (
                  ProductName.Create(name), 
                  ProductPrice.Create(price), 
                  inStock, 
                  categoryId,
                  status
                );
        }

    }
}
