using WebApplication1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Test> Test { get; set; }
    }
}
