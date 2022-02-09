using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Helpers.AutoMapperProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}
