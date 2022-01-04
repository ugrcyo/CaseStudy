using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Core.Models;

namespace Stock.Data.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {


        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(m => m.Name).IsUnique();
            builder.Property(m => m.Name).IsRequired();
            builder.ToTable("Colors");
        }
    }
}
