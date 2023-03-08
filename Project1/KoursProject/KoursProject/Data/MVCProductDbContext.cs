using KoursProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

    namespace KoursProject.Data
    {
        public class MVCProductDbContext : DbContext
        {
            public MVCProductDbContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<Autos> Autos { get; set; }
            public DbSet<Products> Products { get; set; }
            public DbSet<Drivers> Drivers { get; set; }
            public DbSet<Organizations> Organizations { get; set; }
            public DbSet<Invoices> Invoices { get; set; }
            public DbSet<Order> Order { get; set; }
        }
    }
