using Microsoft.EntityFrameworkCore;

namespace ProductsProjectHomework.Models
{
    public class ProductDbContext:DbContext
    {
       public DbSet<Product> products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ProductDB");
        }
    }
}
