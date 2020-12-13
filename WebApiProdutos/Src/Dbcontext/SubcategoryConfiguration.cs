using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiProdutos.Src.Models;

namespace WebApiProdutos.Src.Dbcontext
{
    public class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(25).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.IsActive).HasDefaultValue(true);
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.HasOne(e => e.Category).WithMany().IsRequired();
            builder.Property(e => e.LastModification);
            builder.Property(e => e.RegisterDate);
        }
    }
}
