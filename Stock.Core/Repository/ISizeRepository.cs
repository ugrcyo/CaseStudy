using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stock.Core.Models;

namespace Stock.Core.Repository
{
    public interface ISizeRepository : IRepository<Size>
    {
        Task<Size> GetAllWithSizesByColorNameAsync(string sizeName);

    }
}
