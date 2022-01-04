using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stock.Core.Models;

namespace Stock.Core.Services
{
    public interface IStockService
    {
        Task<IEnumerable<StockInfo>> GetStocksByProductId(int productId);
        Task<StockInfo> GetStocksByVariantId(int variantId);


        Task<StockInfo> CreateStockInfo(StockInfo newStockInfo);
        Task UpdateStockInfo();

    }
}
