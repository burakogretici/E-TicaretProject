using AutoMapper;
using Business.Handlers.Countries.Commands;
using Entities.Concrete;
using Entities.Dtos.Countries;

namespace Business.Helpers.AutoMapperProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CreateCountryCommand>().ReverseMap();
            CreateMap<Country, DeleteCountryCommand>().ReverseMap();
            CreateMap<Country, UpdateCountryCommand>().ReverseMap();

        }
    }
}
