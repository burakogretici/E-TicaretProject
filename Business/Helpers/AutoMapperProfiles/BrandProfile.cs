using AutoMapper;
using Business.Handlers.Brands.Commands;
using Entities.Concrete;
using Entities.Dtos.Brands;

namespace Business.Helpers.AutoMapperProfiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
            CreateMap<BrandDto, CreateBrandCommand>().ReverseMap();
            CreateMap<BrandDto, DeleteBrandCommand>().ReverseMap(); 
            CreateMap<BrandDto, UpdateBrandCommand>().ReverseMap();

        }
    }
}