using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Infrastructure.Configurations.Product
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductManager.Domain.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<ProductManager.Domain.Entities.Product> builder)
        {
           builder.ToTable("products");

           builder.HasKey(x => x.Id);

           builder.OwnsOne(p => p.Name, name =>
            {
                name.Property(n => n.Value)               
                    .HasColumnName("name")
                    .IsRequired()
                    .HasMaxLength(100);
            });

            builder.OwnsOne(p => p.Price, price =>
            {
                price.Property(n => n.Value)
                .HasColumnName("price")
                .IsRequired();
            });

            builder.Property(p => p.InStock).IsRequired();

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId);
            
        }
    }
}
