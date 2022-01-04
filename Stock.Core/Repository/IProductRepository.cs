using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stock.Core.Models;

namespace Stock.Core.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetAllWithProductsByProductCodeAsync(string productCode);

    }
}


