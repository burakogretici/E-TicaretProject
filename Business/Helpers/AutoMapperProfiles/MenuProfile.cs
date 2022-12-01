using AutoMapper;
using Business.Handlers.Cities.Commands;
using Business.Handlers.Menus.Commands;
using Entities.Concrete;
using Entities.Dtos.Cities;
using Entities.Dtos.Menus;

namespace Business.Helpers.AutoMapperProfiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<Menu, CreateMenuCommand>().ReverseMap();
            CreateMap<Menu, DeleteMenuCommand>().ReverseMap();
            CreateMap<Menu, UpdateMenuCommand>().ReverseMap();

            CreateMap<MenuDto, CreateMenuCommand>().ReverseMap();
            CreateMap<MenuDto, DeleteMenuCommand>().ReverseMap();
            CreateMap<MenuDto, UpdateMenuCommand>().ReverseMap();
        }
    }
}