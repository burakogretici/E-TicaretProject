using AutoMapper;
using Business.Handlers.Products.Commands;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Products;

namespace Business.Helpers.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<PaginatedResult<Product>, PaginatedResult<ProductListDto>>().ReverseMap();

            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();

            CreateMap<ProductDto, CreateProductCommand>().ReverseMap();
            CreateMap<ProductDto, DeleteProductCommand>().ReverseMap();
            CreateMap<ProductDto, UpdateProductCommand>().ReverseMap();
        }
    }
}