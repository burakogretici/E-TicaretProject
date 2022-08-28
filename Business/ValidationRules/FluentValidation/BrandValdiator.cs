using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValdiator : AbstractValidator<Brand>
    {
        public BrandValdiator()
        {

        }
    }
}
