using AutoMapper;
using Business.Handlers.Countries.Commands;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Countries;

namespace Business.Helpers.AutoMapperProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();

            CreateMap<PaginatedResult<Country>, CountryDto>().ReverseMap();
            CreateMap<PaginatedResult<Country>, Country>().ReverseMap();
            CreateMap<PaginatedResult<Country>, PaginatedResult<CountryDto>>().ReverseMap();

            CreateMap<Country, CreateCountryCommand>().ReverseMap();
            CreateMap<Country, DeleteCountryCommand>().ReverseMap();
            CreateMap<Country, UpdateCountryCommand>().ReverseMap();

            CreateMap<CountryDto, CreateCountryCommand>().ReverseMap();
            CreateMap<CountryDto, DeleteCountryCommand>().ReverseMap();
            CreateMap<CountryDto, UpdateCountryCommand>().ReverseMap();

        }
    }
}
