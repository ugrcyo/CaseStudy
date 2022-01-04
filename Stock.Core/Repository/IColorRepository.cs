using System;
using System.Threading.Tasks;
using Stock.Core.Models;

namespace Stock.Core.Repository
{
    public interface IColorRepository : IRepository<Color>
    {
        Task<Color> GetAllWithColorsByColorNameAsync(string colorName);

    }
}
