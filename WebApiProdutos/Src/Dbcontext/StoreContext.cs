﻿using Microsoft.EntityFrameworkCore;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Dbcontext
{
    public class StoreContext : DbContext
    {
        #region DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> SubCategories { get; set; }
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
            base.OnModelCreating(modelBuilder);
        }


    }
}
