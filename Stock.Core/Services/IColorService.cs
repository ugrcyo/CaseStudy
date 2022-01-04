using System;
using System.Threading.Tasks;
using Stock.Core.Models;

namespace Stock.Core.Services
{
    public interface IColorService
    {
        Task<Color> GetColorByColorName(string colorName);

        Task<Color> CreateColor(Color newColor);

    }
}
