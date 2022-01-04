using System;
using System.Threading.Tasks;
using Stock.Core;
using Stock.Core.Models;
using Stock.Core.Services;

namespace Stock.Service
{
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork unitOfWork;

        public ColorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Color> CreateColor(Color newColor)
        {
            await unitOfWork.Colors.AddAsync(newColor);

            await unitOfWork.CommitAsync();

            return newColor;
        }

        public async Task<Color> GetColorByColorName(string colorName)
        {
            return await unitOfWork.Colors.GetAllWithColorsByColorNameAsync(colorName);
        }
    }
}
