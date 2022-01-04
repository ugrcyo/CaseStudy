using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stock.Core.Models;
using Stock.Core.Repository;

namespace Stock.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(StockDbContext context)
          : base(context)
        { }
        private StockDbContext StockDbContext
        {
            get { return Context as StockDbContext; }
        }

        public async Task<Product> GetAllWithProductsByProductCodeAsync(string productCode)
        {
            return await StockDbContext.Products.Where(m => m.ProductCode == productCode).SingleOrDefaultAsync();
        }

    }
}
