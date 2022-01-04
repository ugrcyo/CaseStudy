using System;
using FluentValidation;
using Stock.Api.DTO;

namespace Stock.Api.Validator
{
    public class ProductCodeValidator : AbstractValidator<StockDTO>
    {
        public ProductCodeValidator()
        {
            RuleFor(x => x.ProductCode).Length(1).WithMessage("For example : X");

        }
    }
}
