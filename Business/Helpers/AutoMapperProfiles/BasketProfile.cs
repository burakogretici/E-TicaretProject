using AutoMapper;
using Business.Handlers.Baskets.Commands;
using Entities.Concrete;
using Entities.Dtos.Baskets;

namespace Business.Helpers.AutoMapperProfiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketDto>().ReverseMap();

            CreateMap<Basket, CreateBasketCommand>().ReverseMap();
            CreateMap<Basket, DeleteBasketCommand>().ReverseMap();
            CreateMap<Basket, UpdateBasketCommand>().ReverseMap();

        }
    }
}