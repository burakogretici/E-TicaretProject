using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Addresses;
using Core.Utilities.Results;
using Entities.Dtos.Addresses;
using MediatR;

namespace Business.Handlers.Addresses.Commands
{
    public class CreateAddressCommand : IRequest<IResult>
    {
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }

        public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, IResult>
        {
            private readonly IAddressService _addressService;
            private readonly IMapper _mapper;

            public CreateAddressCommandHandler(IAddressService addressService, IMapper mapper)
            {
                _addressService = addressService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<AddressDto>(request);
                var address = await _addressService.AddAsync(mapper);
                return address;
            }
        }
    }
}

