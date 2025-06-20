using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;
using ProductManager.Infrastructure.Data;
using ProductManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection InfrastructureInit(this IServiceCollection services,string connectionString)
        {

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddTransient<IRepository<Category>, EfRepository<Category>>();
            services.AddTransient<IRepository<Product>, EfRepository<Product>>();
            services.AddTransient<IRepository<User>, EfRepository<User>>();

            return services;
        }
    }
}
