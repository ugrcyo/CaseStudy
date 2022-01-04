using System;
using System.Threading.Tasks;
using Stock.Core;
using Stock.Core.Models;
using Stock.Core.Services;

namespace Stock.Service
{
    public class SizeService : ISizeService
    {
        private readonly IUnitOfWork unitOfWork;

        public SizeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Size> CreateSize(Size newSize)
        {
            await unitOfWork.Sizes.AddAsync(newSize);

            await unitOfWork.CommitAsync();

            return newSize;
        }

        public async Task<Size> GetSizeBySizeName(string sizeName)
        {
            return await unitOfWork.Sizes.GetAllWithSizesByColorNameAsync(sizeName);
        }
    }
}
