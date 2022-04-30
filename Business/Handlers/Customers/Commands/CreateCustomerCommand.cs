using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Enums;
using MediatR;

namespace Business.Handlers.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<IResult>
    {
        public Guid UserId { get; set; }
        public CustomerType? CustomerType { get; set; }
        
        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateCustomerCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Customer>(request);
                await _unitOfWork.CustomerRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CustomerAdded);
            }
        }
    }
}