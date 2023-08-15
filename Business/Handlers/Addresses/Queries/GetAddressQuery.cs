using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Addresses;
using Core.Utilities.Results;
using Entities.Dtos.Addresses;
using MediatR;

namespace Business.Handlers.Addresses.Queries
{
    public class GetAddressQuery : IRequest<IDataResult<AddressDto>>
    {
        public Guid Id { get; set; }

        public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, IDataResult<AddressDto>>
        {
            private readonly IAddressService _addressService;

            public GetAddressQueryHandler(IAddressService addressService)
            {
                _addressService = addressService;
            }

            public async Task<IDataResult<AddressDto>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
            {
                var address = await _addressService.GetByIdAsync(request.Id);
                return address;
            }
        }
    }
}
