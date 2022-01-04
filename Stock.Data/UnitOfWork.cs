using System;
using System.Threading.Tasks;
using Stock.Core;
using Stock.Core.Repository;
using Stock.Data.Repositories;

namespace Stock.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StockDbContext context;
        private StockRepository stockRepository;
        private ProductRepository productRepository;
        private VariantRepository variantRepository;
        private SizeRepository sizeRepository;
        private ColorRepository colorRepository;

        public UnitOfWork(StockDbContext context)
        {
            this.context = context;
        }

        public IProductRepository Products => productRepository = productRepository ?? new ProductRepository(this.context);

        public IVariantRepository Variants => variantRepository = variantRepository ?? new VariantRepository(this.context);

        public IStockRepository Stocks => stockRepository = stockRepository ?? new StockRepository(this.context);

        public ISizeRepository Sizes => sizeRepository = sizeRepository ?? new SizeRepository(this.context);

        public IColorRepository Colors => colorRepository = colorRepository ?? new ColorRepository(this.context);


        public async Task<int> CommitAsync()
        {
            return await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
