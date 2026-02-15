using Microsoft.EntityFrameworkCore;
using WPFBoilerPlate.Models.Entities;

namespace WPFBoilerPlate.Utils
{
    public class AppDBContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=mydb.db");
        }
    }
}
