using Kours.Domain;
using Kours.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kours.DAL
{
    public class MVCProductDbContext : DbContext
    {
        public MVCProductDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Autos> Autos { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<Organizations> Organizations { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Order> Order { get; set; }

    }
}
