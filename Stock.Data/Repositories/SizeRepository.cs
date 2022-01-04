using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stock.Core.Models;
using Stock.Core.Repository;

namespace Stock.Data.Repositories
{
    public class SizeRepository : Repository<Size> , ISizeRepository
    {
        public SizeRepository(StockDbContext context)
       : base(context)
        { }
        private StockDbContext StockDbContext
        {
            get { return Context as StockDbContext; }
        }

        public async Task<Size> GetAllWithSizesByColorNameAsync(string sizeName)
        {
            return await StockDbContext.Sizes.Where(m => m.Name == sizeName).SingleOrDefaultAsync();
        }
    }
}
