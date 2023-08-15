using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Addresses;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Addresses;
using MediatR;

namespace Business.Handlers.Addresses.Queries
{
    public class GetAddressesTableQuery : IRequest<PaginatedResult<AddressListDto>>
    {
        public TableGlobalFilter TableGlobalFilter { get; set; }

        public class GetAddressesTableQueryHandler : IRequestHandler<GetAddressesTableQuery, PaginatedResult<AddressListDto>>
        {
            private readonly IAddressService _addressService;

            public GetAddressesTableQueryHandler(IAddressService addressService)
            {
                _addressService = addressService;
            }

            public async Task<PaginatedResult<AddressListDto>> Handle(GetAddressesTableQuery request,
                CancellationToken cancellationToken)
            {
                var addressList = await _addressService.GetTableSearch(request.TableGlobalFilter);
                return addressList;

            }
        }
    }
}