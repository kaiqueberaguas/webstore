using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webApi.src.models;

namespace webApi.src.dbcontext
{
    public class StoreContext : IdentityDbContext
    {
        #region DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> SubCategories { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion

        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SubcategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PriceConfiguration());
            base.OnModelCreating(modelBuilder);
        }


    }
}
