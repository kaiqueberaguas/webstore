using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.models;

namespace webApi.src.dbcontext
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(25).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Information).HasMaxLength(400);
            builder.Property(e => e.AvailableQuantity).HasDefaultValue(0);
            builder.Property(e => e.LimitDate);
            builder.Property(e => e.PurchaseDate).IsRequired();
            builder.HasOne(e => e.Subcategory).WithMany(e => e.Products).HasForeignKey(e => e.SubcategoryId).IsRequired();
            builder.HasMany(e => e.Prices).WithOne(p => p.Product);
            builder.Property(e => e.LastModification);
            builder.Property(e => e.RegisterDate);
        }
    }
}
