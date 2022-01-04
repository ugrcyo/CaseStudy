using System;
using System.Threading.Tasks;
using Stock.Core.Repository;

namespace Stock.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IVariantRepository Variants { get; }
        IStockRepository Stocks { get; }
        ISizeRepository Sizes { get; }
        IColorRepository Colors { get; }
        Task<int> CommitAsync();
    }
}
