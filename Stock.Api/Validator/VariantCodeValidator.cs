using System;
using FluentValidation;
using Stock.Api.DTO;

namespace Stock.Api.Validator
{
    public class VariantCodeValidator : AbstractValidator<StockDTO>
    {
        public VariantCodeValidator()
        {
            RuleFor(x => x.VariantCode).Length(5).WithMessage("For example : X0001");

        }
    }
}
