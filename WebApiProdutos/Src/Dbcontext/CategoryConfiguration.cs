using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Dbcontext
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(25);
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.IsActive).HasDefaultValue(true);
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.HasMany(e => e.Subcategories).WithOne(e => e.Category);
            builder.Property(e => e.LastModification);
            builder.Property(e => e.RegisterDate);
        }
    }
}
