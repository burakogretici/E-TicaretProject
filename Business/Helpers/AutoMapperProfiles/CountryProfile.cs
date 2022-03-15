using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Countries;

namespace Business.Helpers.AutoMapperProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<CountryDto, Country>().ReverseMap();
        }
    }
}
