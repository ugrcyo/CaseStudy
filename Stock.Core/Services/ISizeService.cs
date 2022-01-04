using System;
using System.Threading.Tasks;
using Stock.Core.Models;

namespace Stock.Core.Services
{
    public interface ISizeService
    {
        Task<Size> GetSizeBySizeName(string sizeName);

        Task<Size> CreateSize(Size newSize);
    }
}
