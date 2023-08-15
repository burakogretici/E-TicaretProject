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
    public class DeleteAddressCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        
        public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, IResult>
        {
            private readonly IAddressService _addressService;
            private readonly IMapper _mapper;

            public DeleteAddressCommandHandler(IAddressService addressService, IMapper mapper)
            {
                _addressService = addressService;
                _mapper = mapper;
            }
            public async Task<IResult> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<AddressDto>(request);
                var address = await _addressService.DeleteAsync(mapper);
                return address;
            }
        }
    }
}
