using Entities.Dtos.Categories;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(3);
        }
    }
}
