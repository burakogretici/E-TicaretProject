using Entities.Dtos.Colors;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<ColorDto>
    {
        public ColorValidator()
        {

        }
    }
}
