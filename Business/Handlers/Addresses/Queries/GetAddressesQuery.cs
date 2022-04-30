using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework.Context;
using DataAccess.UnitOfWork;
using Entities.Dtos.Addresses;
using MediatR;

namespace Business.Handlers.Addresses.Queries
{
    public class GetAddressesQuery : IRequest<IDataResult<IEnumerable<AddressDto>>>
    {
        public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQuery, IDataResult<IEnumerable<AddressDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAddressesQueryHandler(IUnitOfWork unitOfWork, EticaretContext context)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<AddressDto>>> Handle(GetAddressesQuery request,
                CancellationToken cancellationToken)
            {
                var brandList = await _unitOfWork.AddressRepository.GetAllAsync(x => new AddressDto
                {
                    Id = x.Id,
                    CustomerFullName = x.Customer.User.FirstName + " " + x.Customer.User.LastName,
                    Country = x.Country.Name,
                    City = x.City.Name,
                    AddressDetail = x.AddressDetail,
                    PostalCode = x.PostalCode
                });
                return new SuccessDataResult<IEnumerable<AddressDto>>(brandList);


            }
        }
    }
}
