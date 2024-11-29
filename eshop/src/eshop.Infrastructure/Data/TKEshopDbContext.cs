using eshop.Domain;
using Microsoft.EntityFrameworkCore;

namespace eshop.Infrastructure.Data
{
    public class TKEshopDbContext : DbContext
    {
        public TKEshopDbContext(DbContextOptions<TKEshopDbContext> option) : base(option)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.u
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var categories = new Category[]
            {
                new(){Id = 1, Name = "Elektronik"},
                new(){Id = 2, Name = "Giyim"},
                new(){Id = 3, Name = "Kozmetik"}
            };
            modelBuilder.Entity<Category>().HasData(categories);

            var products = new Product[] {
                new(){Id = 1, Name = "Dell Xps 15", Price = 10, Description = "Laptop Açıklama", ImageUrl = "testimage", CategoryId = 1},
                new(){Id = 2, Name = "Kazak", Price = 20, Description = "Kazak Açıklama", ImageUrl = "testimage", CategoryId = 2},
                new(){Id = 3, Name = "Ruj", Price = 30, Description = "Ruj  Açıklama", ImageUrl = "testimage", CategoryId = 3}
            };

            modelBuilder.Entity<Product>().HasData(products);





        }

    }
}
