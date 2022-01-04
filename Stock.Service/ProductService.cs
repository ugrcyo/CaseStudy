using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stock.Core;
using Stock.Core.Models;
using Stock.Core.Services;

namespace Stock.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Product> CreateProduct(Product newProduct)
        {
            await unitOfWork.Products.AddAsync(newProduct);

            await unitOfWork.CommitAsync();

            return newProduct;
        }

        public async Task<Product> GetProductByProductCode(string productCode)
        {
            return await unitOfWork.Products.GetAllWithProductsByProductCodeAsync(productCode);
        }
    }
}

