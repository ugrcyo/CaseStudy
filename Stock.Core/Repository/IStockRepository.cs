using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stock.Core.Models;

namespace Stock.Core.Repository
{
    public interface IStockRepository : IRepository<StockInfo>
    {
        Task<IEnumerable<StockInfo>> GetAllWithProductsByProductIdAsync(int productId);

        Task<StockInfo> GetAllWithVariantsByVariantIdAsync(int variantId);
    }

}
