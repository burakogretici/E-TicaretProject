using AutoMapper;
using Business.Handlers.BasketItems.Commands;
using Entities.Concrete;
using Entities.Dtos.Baskets;

namespace Business.Helpers.AutoMapperProfiles
{
    public class BasketItemProfile : Profile
    {
        public BasketItemProfile()
        {
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();

            CreateMap<BasketItem, CreateBasketItemCommand>().ReverseMap();
            CreateMap<BasketItem, DeleteBasketItemCommand>().ReverseMap();
            CreateMap<BasketItem, UpdateBasketItemCommand>().ReverseMap();

                    CreateMap<BasketItemDto, CreateBasketItemCommand>().ReverseMap();
            CreateMap<BasketItemDto, DeleteBasketItemCommand>().ReverseMap();
            CreateMap<BasketItemDto, UpdateBasketItemCommand>().ReverseMap();

        }
    }
}