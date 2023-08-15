using Entities.Dtos.Products;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator :AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori seçimi boş geçilemez!");
            RuleFor(p => p.BrandId).NotEmpty().WithMessage("Marka seçimi boş geçilemez!");
            RuleFor(p => p.ColorId).NotEmpty().WithMessage("Renk seçimi boş geçilemez!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün adınız boş geçilemez!");

        }
    }
}
