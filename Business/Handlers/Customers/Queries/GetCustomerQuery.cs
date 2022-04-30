using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Customers;
using MediatR;

namespace Business.Handlers.Customers.Queries
{
    public class GetCustomerQuery : IRequest<IDataResult<CustomerDto>>
    {
        public Guid Id { get; set; }

        public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, IDataResult<CustomerDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
            {
                var customer = await _unitOfWork.CustomerRepository.GetAsync(a => a.Id == request.Id);
                var customerDto = _mapper.Map<CustomerDto>(customer);
                return new SuccessDataResult<CustomerDto>(customerDto);
            }
        }
    }
}
