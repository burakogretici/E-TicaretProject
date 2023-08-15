using Entities.Dtos.Cities;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CityValidator : AbstractValidator<CityDto>
    {
        public CityValidator()
        {

        }
    }
}
