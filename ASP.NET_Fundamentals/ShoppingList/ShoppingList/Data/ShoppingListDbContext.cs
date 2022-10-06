using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;

namespace ShoppingList.Data
{
    public class ShoppingListDbContext : DbContext
    {
        /// <summary>
        /// Shopping list db context constructor
        /// </summary>
        /// <param name="options"></param>
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Products db set (entity)
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Product notes db set (entity)
        /// </summary>
        public DbSet<ProductNote> ProductNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasMany(p => p.ProductNotes)
                .WithOne(r => r.Product);
        }

        public DbSet<ShoppingList.Models.ProductViewModel> ProductViewModel { get; set; }
    }
}
