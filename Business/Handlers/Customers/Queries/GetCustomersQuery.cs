using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Customers;
using MediatR;

namespace Business.Handlers.Customers.Queries
{
    public class GetCustomersQuery : IRequest<IDataResult<IEnumerable<CustomerDto>>>
    {
        public class GetColorsQueryHandler : IRequestHandler<GetCustomersQuery, IDataResult<IEnumerable<CustomerDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetColorsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<CustomerDto>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
            {
                var customerList = await _unitOfWork.CustomerRepository.GetAllAsync(
                    selector: x => new CustomerDto
                    {
                        Id = x.Id,
                        CustomerFullName = x.User.FirstName + " " + x.User.LastName,
                        CustomerType = x.CustomerType
                    }
                );
                return new SuccessDataResult<IEnumerable<CustomerDto>>(customerList);
            }
        }
    }
}
