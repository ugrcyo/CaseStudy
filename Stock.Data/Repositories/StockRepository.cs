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
    public class StockRepository : Repository<StockInfo>, IStockRepository
    {
        public StockRepository(StockDbContext context)
        : base(context)
        { }
        private StockDbContext StockDbContext
        {
            get { return Context as StockDbContext; }
        }

        public async Task<IEnumerable<StockInfo>> GetAllWithProductsByProductIdAsync(int productId)
        {
            return await StockDbContext.StockInfos.Where(m => m.ProductId == productId).ToListAsync();
        }

        public async Task<StockInfo> GetAllWithVariantsByVariantIdAsync(int variantId)
        {
            return await StockDbContext.StockInfos.Where(m => m.VariantId == variantId).SingleOrDefaultAsync();
        }

       

    }
}
