using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Cities;

namespace Business.Helpers.AutoMapperProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<CityDto, City>().ReverseMap();
        }
    }
}
