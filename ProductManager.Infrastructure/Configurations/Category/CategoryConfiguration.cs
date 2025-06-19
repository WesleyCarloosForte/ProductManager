using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Infrastructure.Configurations.Category
{
    public class CategoryConfiguration:IEntityTypeConfiguration<ProductManager.Domain.Entities.Category>
    {
        public void Configure(EntityTypeBuilder<ProductManager.Domain.Entities.Category> builder)
        {
            builder.ToTable("categories");

            builder.HasKey(x => x.Id);


            builder.OwnsOne(c => c.Name, name =>
            {
                name.Property(n => n.Value)
                    .HasColumnName("name")
                    .IsRequired()
                    .HasMaxLength(100);
            });

            builder.HasMany(c => c.Products)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId);
        }
    }
}
