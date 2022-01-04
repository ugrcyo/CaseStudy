using System;
using Microsoft.EntityFrameworkCore;
using Stock.Core.Models;
using Stock.Data.Configurations;

namespace Stock.Data
{
    public class StockDbContext : DbContext
    {
        public DbSet<StockInfo> StockInfos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }

        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StockConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new VariantConfiguration());
            builder.ApplyConfiguration(new SizeConfiguration());
            builder.ApplyConfiguration(new ColorConfiguration());

        }

    }
}
