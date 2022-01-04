using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stock.Core.Models;
using Stock.Core.Repository;

namespace Stock.Data.Repositories
{
    public class ColorRepository : Repository<Color> , IColorRepository
    {
        public ColorRepository(StockDbContext context)
        : base(context)
        { }
        private StockDbContext StockDbContext
        {
            get { return Context as StockDbContext; }
        }

        public async Task<Color> GetAllWithColorsByColorNameAsync(string colorName)
        {
            return await StockDbContext.Colors.Where(m => m.Name == colorName).SingleOrDefaultAsync();
        }
    }
}
