using AutoMapper;
using Business.Handlers.Orders.Commands;
using Entities.Concrete;
using Entities.Dtos.Orders;

namespace Business.Helpers.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, DeleteOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}