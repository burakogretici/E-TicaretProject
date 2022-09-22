using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Addresses;
using Core.Utilities.Results;
using Entities.Dtos.Addresses;
using MediatR;

namespace Business.Handlers.Addresses.Queries
{
    public class GetAddressesQuery : IRequest<IDataResult<IEnumerable<AddressListDto>>>
    {
        public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQuery, IDataResult<IEnumerable<AddressListDto>>>
        {
            private readonly IAddressService _addressService;

            public GetAddressesQueryHandler(IAddressService addressService)
            {
                _addressService = addressService;
            }

            public async Task<IDataResult<IEnumerable<AddressListDto>>> Handle(GetAddressesQuery request,
                CancellationToken cancellationToken)
            {
                var addressList = await _addressService.GetAllAsync();
                return addressList;

            }

        }
    }
}
