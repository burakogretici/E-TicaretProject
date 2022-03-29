using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Brands;

namespace Business.Helpers.AutoMapperProfiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<BrandDto, Brand>().ReverseMap();
        }
    }
}