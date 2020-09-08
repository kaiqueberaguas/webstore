using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Information).HasMaxLength(400);
            builder.Property(e => e.AvailableQuantity);
            builder.Property(e => e.LimitDate);
            builder.Property(e => e.PurchaseDate).IsRequired();
            builder.Property(e => e.Amount).IsRequired();
            builder.HasOne(e => e.Subcategory).WithMany(e => e.Products).HasForeignKey(e => e.SubcategoryId).IsRequired();
            builder.Property(e => e.LastModification);
            builder.Property(e => e.RegisterDate);
        }
    }
}
