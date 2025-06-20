using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManager.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Infrastructure.Configurations.User
{
    public class UserConfiguration:IEntityTypeConfiguration<ProductManager.Domain.Entities.User>
    {
        public void Configure(EntityTypeBuilder<ProductManager.Domain.Entities.User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(t => t.Id);

            builder.OwnsOne(u => u.Login, login =>
            {
                login.Property(l => l.Value)
                     .HasColumnName("login")
                     .HasMaxLength(100)
                     .IsRequired();
            });

            builder.OwnsOne(u => u.PasswordHash, login =>
            {
                login.Property(l => l.Value)
                     .HasColumnName("password_hash")
                     .HasMaxLength(100)
                     .IsRequired();
            });

            builder.Property(u => u.Permissions)
                  .HasConversion(
                      v => string.Join(';', v.Select(p => p.ToString())),
                      v => v.Split(';', StringSplitOptions.RemoveEmptyEntries)
                            .Select(p => Enum.Parse<Permission>(p))
                            .ToList()
                  )
                  .HasColumnName("permissions")
                  .IsRequired();

            builder.OwnsOne(u => u.FullName, fullName =>
            {
                fullName.Property(f => f.Value)
                .HasColumnName("full_name")
                .HasMaxLength(100)
                .IsRequired();
            });
        }
    }
}
