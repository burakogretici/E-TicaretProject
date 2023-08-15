using Entities.Dtos.Brands;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<BrandDto>
    {
        public BrandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Marka Boş geçilemez");

        }
    }
}
