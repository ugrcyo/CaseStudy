using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stock.Core.Models;

namespace Stock.Core.Services
{
    public interface IVariantService
    {
        Task<IEnumerable<Variant>> GetVariantByProductId(int productId);

        Task<Variant> GetVariantByVariantCode(string variantCode);

        Task<Variant> CreateVariant(Variant newVariant);
    }
}
