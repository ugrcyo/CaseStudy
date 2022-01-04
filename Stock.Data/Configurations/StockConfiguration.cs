using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Core.Models;

namespace Stock.Data.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<StockInfo>
    {

        public void Configure(EntityTypeBuilder<StockInfo> builder)
        {
            builder
              .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.ProductId)
                .IsRequired();

            builder
                .HasOne(m => m.Product)
                .WithMany(a => a.Stocks)
                .HasForeignKey(m => m.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Property(m => m.VariantId)
                .IsRequired();

            builder
                .HasOne(m => m.Variant)
                .WithMany(a => a.Stocks)
                .HasForeignKey(m => m.VariantId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.Property(m => m.Quantity).HasDefaultValue(0);
            builder.Property(m => m.CreateTime).HasDefaultValue(DateTime.Now);
            builder.Property(m => m.UpdateTime).HasDefaultValue("0001.01.01");

            builder.ToTable("StockInfos");
        }
    }
}

