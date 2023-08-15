using AutoMapper;
using Business.Handlers.Brands.Commands;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Brands;
using Entities.Dtos.Products;
using System.Collections.Generic;

namespace Business.Helpers.AutoMapperProfiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();

            CreateMap<PaginatedResult<Brand>, BrandDto>().ReverseMap();
            CreateMap<PaginatedResult<Brand>, Brand>().ReverseMap();
            CreateMap<PaginatedResult<Brand>, PaginatedResult<BrandDto>>().ReverseMap();

            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();

            CreateMap<BrandDto, CreateBrandCommand>().ReverseMap();
            CreateMap<BrandDto, DeleteBrandCommand>().ReverseMap(); 
            CreateMap<BrandDto, UpdateBrandCommand>().ReverseMap();

        }
    }
}