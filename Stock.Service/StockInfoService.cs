using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stock.Core;
using Stock.Core.Models;
using Stock.Core.Services;

namespace Stock.Service
{
    public class StockInfoService : IStockService
    {
        private readonly IUnitOfWork unitOfWork;

        public StockInfoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<StockInfo> CreateStockInfo(StockInfo newStockInfo)
        {
            await unitOfWork.Stocks.AddAsync(newStockInfo);

            await unitOfWork.CommitAsync();

            return newStockInfo;
        }

        public async Task<IEnumerable<StockInfo>> GetStocksByProductId(int productId)
        {
            return await unitOfWork.Stocks.GetAllWithProductsByProductIdAsync(productId);
        }

        public async Task<StockInfo> GetStocksByVariantId(int variantId)
        {
            return await unitOfWork.Stocks.GetAllWithVariantsByVariantIdAsync(variantId);

        }

        public async Task UpdateStockInfo()
        {
             await unitOfWork.CommitAsync();
        }
    }
}
