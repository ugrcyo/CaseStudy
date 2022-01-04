using Microsoft.EntityFrameworkCore;
using Stock.Core.Models;
using Stock.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Data.Repositories
{
    public class VariantRepository : Repository<Variant> , IVariantRepository
    {
        public VariantRepository(StockDbContext context)
         : base(context)
        { }
        private StockDbContext StockDbContext
        {
            get { return Context as StockDbContext; }
        }

        public async Task<IEnumerable<Variant>> GetAllWithVariantsByProductIdAsync(int productId)
        {
            return await StockDbContext.Variants.Include(m => m.Product).Where(m => m.ProductId == productId).ToListAsync();
        }

        public async Task<Variant> GetAllWithVariantsByVariantCodeAsync(string variantCode)
        {
            return await StockDbContext.Variants.Where(m => m.VariantCode == variantCode).SingleOrDefaultAsync();
        }
    }
}
