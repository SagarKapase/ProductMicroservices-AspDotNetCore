using Microsoft.EntityFrameworkCore;
using ProductMicroservices.Models;

namespace ProductMicroservices.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> categories { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

            new Category
            {
                Id = 1,
                Name = "Electronics",
                Description = "These are electronics items"
            },
            new Category
            {
                Id = 2,
                Name = "Clothes",
                Description = "These are Dresses"
            },
            new Category
            {
                Id = 3,
                Name = "Grocery",
                Description = "These are Grocery items"
            }) ;
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
        }
    }
}
