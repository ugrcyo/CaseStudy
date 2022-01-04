using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stock.Core;
using Stock.Core.Models;
using Stock.Core.Services;

namespace Stock.Service
{
    public class VariantService : IVariantService
    {
        private readonly IUnitOfWork unitOfWork;

        public VariantService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Variant> CreateVariant(Variant newVariant)
        {
            await unitOfWork.Variants.AddAsync(newVariant);

            await unitOfWork.CommitAsync();

            return newVariant;
        }

        public async Task<IEnumerable<Variant>> GetVariantByProductId(int productId)
        {
            return await unitOfWork.Variants.GetAllWithVariantsByProductIdAsync(productId);
        }

        public async Task<Variant> GetVariantByVariantCode(string variantCode)
        {
            return await unitOfWork.Variants.GetAllWithVariantsByVariantCodeAsync(variantCode);
        }
    }
}
