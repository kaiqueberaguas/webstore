using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using webApi.src.models;

namespace webApi.src.dbcontext
{
    public class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(25).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.HasMany(e => e.Products).WithOne();
            builder.HasOne(e => e.Category).WithMany().IsRequired();
            builder.Property(e => e.LastModification).ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.RegisterDate).ValueGeneratedOnAdd();
            builder.Property(e => e.OriginRegister).HasMaxLength(25);
        }
    }
}
