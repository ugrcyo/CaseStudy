using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Core.Models;

namespace Stock.Data.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {


        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(m => m.Name).IsUnique();
            builder.Property(m => m.Name).IsRequired();
            builder.ToTable("Sizes");
        }
    }
}


