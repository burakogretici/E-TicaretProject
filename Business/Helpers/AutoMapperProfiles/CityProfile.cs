using AutoMapper;
using Business.Handlers.Cities.Commands;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Cities;
using Entities.Dtos.Products;

namespace Business.Helpers.AutoMapperProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();

            CreateMap<PaginatedResult<City>, CityDto>().ReverseMap();
            CreateMap<PaginatedResult<City>, City>().ReverseMap();
            CreateMap<City, CityListDto>().ReverseMap();
            CreateMap<PaginatedResult<City>, PaginatedResult<CityListDto>>().ReverseMap();


            CreateMap<City, CreateCityCommand>().ReverseMap();
            CreateMap<City, DeleteCityCommand>().ReverseMap();
            CreateMap<City, UpdateCityCommand>().ReverseMap();

            CreateMap<CityDto, CreateCityCommand>().ReverseMap();
            CreateMap<CityDto, DeleteCityCommand>().ReverseMap();
            CreateMap<CityDto, UpdateCityCommand>().ReverseMap();
        }
    }
}
