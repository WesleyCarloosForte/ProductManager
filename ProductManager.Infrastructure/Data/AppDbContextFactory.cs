using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Infrastructure.Data
{
    public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
    {
        //Solo para generar migraciones y evitar el error
        /// <summary>
        /// Porque cuando ejecutás Add-Migration, no se ejecuta Program.cs ni se carga el IServiceCollection. EF Core en diseño (design-time) necesita construir el AppDbContext por sí mismo, y no puede usar tu InfrastructureInit(...) automáticamente.
        /// </summary>

        /// <returns></returns>
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();


            var connectionString = "Host=localhost;Port=5432;Database=product_db;Username=postgres;Password=123456;";

            optionsBuilder.UseNpgsql(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
