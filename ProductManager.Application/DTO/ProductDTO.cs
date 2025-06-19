using ProductManager.Domain.Common;
using ProductManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public bool InStock {  get; set; }
        public string Name { get; set; }
        public Guid CategogyId { get; set; }
        public EntityStatus Status { get; set; }

        public static ProductDTO Create(Product product)
        {
            return new ProductDTO
            {
                CategogyId = product.CategoryId,
                Id = product.Id,
                InStock = product.InStock,
                Name = product.Name.Value,
                Price = product.Price.Value,
                Status = product.Status
            };
        }
        public static IEnumerable<ProductDTO> CreateRange(IEnumerable<Product> product)
        {
            try
            {

                if (!product.Any())
                    return new List<ProductDTO>();

                var elements = new List<ProductDTO>();

                foreach (Product item in product)
                {
                    elements.Add(ProductDTO.Create(item));

                }
                return elements;
            }
            catch (Exception ex)
            {

                return new List<ProductDTO>();
            }
        }
    }
}
