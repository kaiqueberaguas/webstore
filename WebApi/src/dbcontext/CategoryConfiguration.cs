using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.models;

namespace webApi.src.dbcontext
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(25);
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.HasMany(e => e.Subcategories).WithOne(e => e.Category);
            builder.Property(e => e.LastModification).ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.RegisterDate).ValueGeneratedOnAdd();
            builder.Property(e => e.OriginRegister).HasMaxLength(25);
        }
    }
}
