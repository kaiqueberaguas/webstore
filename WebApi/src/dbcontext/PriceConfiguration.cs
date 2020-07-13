using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using webApi.src.models;

namespace webApi.src.dbcontext
{
    public class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Product).IsRequired();            
            builder.Property(e => e.Amount).IsRequired();
            builder.Property(e => e.IsPromotional).HasDefaultValue(false);
            builder.Property(e => e.InitialDate).HasDefaultValue(DateTime.Now);
            builder.Property(e => e.FinalDate).HasDefaultValue(null);
            builder.Property(e => e.LastModification).ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.RegisterDate).ValueGeneratedOnAdd();
            builder.Property(e => e.OriginRegister).HasMaxLength(25);            
        }
    }
}
