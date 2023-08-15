using AutoMapper;
using Core.Utilities.Results;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using Business.Services.Addresses;
using Entities.Dtos.Addresses;

namespace Business.Handlers.Addresses.Commands
{
    public class UpdateAddressCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }
        public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, IResult>
        {
            private readonly IAddressService _addressService;
            private readonly IMapper _mapper;

            public UpdateAddressCommandHandler(IAddressService addressService, IMapper mapper)
            {
                _addressService = addressService;
                _mapper = mapper;
            }
            public async Task<IResult> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<AddressDto>(request);
                var address = await _addressService.UpdateAsync(mapper);
                return address;
            }
        }
    }
}
