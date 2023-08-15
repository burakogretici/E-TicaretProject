using AutoMapper;
using Business.Handlers.Addresses.Commands;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Addresses;
using System.Linq;

namespace Business.Helpers.AutoMapperProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<Address, AddressListDto>()
    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName));

            CreateMap<PaginatedResult<Address>, PaginatedResult<AddressListDto>>().ReverseMap();

            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<Address, DeleteAddressCommand>().ReverseMap();
            CreateMap<Address, UpdateAddressCommand>().ReverseMap();

            CreateMap<AddressDto,CreateAddressCommand>().ReverseMap();
            CreateMap<AddressDto, DeleteAddressCommand>().ReverseMap();
            CreateMap<AddressDto, UpdateAddressCommand>().ReverseMap();
        }
    }
}
