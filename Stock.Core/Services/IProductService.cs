using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stock.Core.Models;

namespace Stock.Core.Services
{
    public interface IProductService
    {
        Task<Product> GetProductByProductCode(string productCode);

        Task<Product> CreateProduct(Product newProduct);
    }
}
