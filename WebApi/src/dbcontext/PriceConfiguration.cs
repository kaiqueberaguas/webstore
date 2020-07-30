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
            builder.HasOne(e => e.Product).WithMany(p => p.Prices).IsRequired();            
            builder.Property(e => e.Amount).HasColumnType("money").IsRequired();
            builder.Property(e => e.IsPromotional).HasDefaultValue(false);
            builder.Property(e => e.InitialDate).HasDefaultValue(DateTime.Now);
            builder.Property(e => e.FinalDate).HasDefaultValue(null);
            builder.Property(e => e.LastModification);
            builder.Property(e => e.RegisterDate);
        }
    }
}
