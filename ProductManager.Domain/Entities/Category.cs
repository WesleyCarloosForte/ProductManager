using ProductManager.Domain.Common;
using ProductManager.Domain.ValueObjects.Category;


namespace ProductManager.Domain.Entities
{
    public class Category : BaseEntity
    {
        public CategoryName Name { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category(CategoryName name, EntityStatus status = EntityStatus.Enabled)
        {
            Name = name;
            Status = status;
        }

        public Category(string name, EntityStatus status = EntityStatus.Enabled)
        {
            Name = CategoryName.Create(name);
            Status = status;
        }
        public Category() 
        {
        
        }

        public static Category Create(string name, EntityStatus status = EntityStatus.Enabled) => new Category { Name = CategoryName.Create(name),Status=status };
    }
}
