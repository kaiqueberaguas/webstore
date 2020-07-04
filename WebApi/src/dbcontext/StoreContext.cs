using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.models;

namespace webApi.src.dbcontext
{
    public class StoreContext : DbContext
    {
        #region DbSets
        public DbSet<Category> Categorias { get; set; }
        public DbSet<Subcategory> SubCategorias { get; set; }
        public DbSet<Product> Produtos { get; set; }
        #endregion

        public StoreContext()
        {
           
        }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
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
