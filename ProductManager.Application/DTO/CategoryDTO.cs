using ProductManager.Domain.Common;
using ProductManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.DTO
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public EntityStatus Status { get; set; }
        public CategoryDTO(Guid id,string name,EntityStatus status)
        {
            Id = id;
            Name=name;  
            Status = status;
        }
        public static CategoryDTO Create(Category category) => new CategoryDTO(category.Id, category.Name.Value, category.Status);
        public static IEnumerable<CategoryDTO> CreateRange(IEnumerable<Category> categories)
        {
            try
            {
                
                if (!categories.Any())
                    return new List<CategoryDTO>();

                var elements = new List<CategoryDTO>();

                foreach(Category item in categories)
                {
                    elements.Add(CategoryDTO.Create(item)); 

                }
                return elements;
            }
            catch (Exception ex)
            {

                return new List<CategoryDTO>();
            }
        }
    }
}
