using AutoMapper;
using Business.Handlers.Cities.Commands;
using Entities.Concrete;
using Entities.Dtos.Cities;

namespace Business.Helpers.AutoMapperProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CreateCityCommand>().ReverseMap();
            CreateMap<City, DeleteCityCommand>().ReverseMap();
            CreateMap<City, UpdateCityCommand>().ReverseMap();
            CreateMap<CityDto, CreateCityCommand>().ReverseMap();
            CreateMap<CityDto, DeleteCityCommand>().ReverseMap();
            CreateMap<CityDto, UpdateCityCommand>().ReverseMap();
        }
    }
}
