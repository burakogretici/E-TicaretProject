using AutoMapper;
using Business.Handlers.Customers.Commands;
using Entities.Concrete;
using Entities.Dtos.Customers;

namespace Business.Helpers.AutoMapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();

        }
    }
}
