using Microsoft.EntityFrameworkCore;

namespace API
{
    public class DB : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./DB.db");
        }

        // Model tables
        public DbSet<Product> Products { get; set; }
    }
}
