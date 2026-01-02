using Microsoft.EntityFrameworkCore;
using WPFBoilerPlate.Models;

namespace WPFBoilerPlate.Utils
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=mydb.db");
        }
    }
}
