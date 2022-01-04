using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stock.Core.Models;

namespace Stock.Core.Repository
{
    public interface IVariantRepository : IRepository<Variant>
    {
        Task<IEnumerable<Variant>> GetAllWithVariantsByProductIdAsync(int productId);
        Task<Variant> GetAllWithVariantsByVariantCodeAsync(string variantCode);

    }
}
