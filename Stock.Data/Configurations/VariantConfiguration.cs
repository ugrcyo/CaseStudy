using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Core.Models;

namespace Stock.Data.Configurations
{
    public class VariantConfiguration : IEntityTypeConfiguration<Variant>
    {
       
        public void Configure(EntityTypeBuilder<Variant> builder)
        {


            builder.HasKey(a => a.Id);
            builder.HasIndex(m => m.Id).IsUnique();

            builder
                .Property(m => m.ProductId)
                .IsRequired();

            builder
                .HasOne(m => m.Product)
                .WithMany(a => a.Variants)
                .HasForeignKey(m => m.ProductId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .Property(m => m.SizeId)
                .IsRequired();

            builder
                .HasOne(m => m.Size)
                .WithMany(a => a.Variants)
                .HasForeignKey(m => m.SizeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(m => m.ColorId)
                .IsRequired();

            builder
                .HasOne(m => m.Color)
                .WithMany(a => a.Variants)
                .HasForeignKey(m => m.ColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Variants");
        }
    }
}
