using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Products;

namespace Business.Helpers.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}