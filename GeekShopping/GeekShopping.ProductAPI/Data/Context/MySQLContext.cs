using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Monitor",
                Price = new decimal(1.10),
                Description = "Tela de pc",
                Category = "Informatica",
                ImageURL = "https://www.digitalavmagazine.com/wp-content/uploads/2020/08/Philips-279C9.jpg"
            });
        }
    }
}
