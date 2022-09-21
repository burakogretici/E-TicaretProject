using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Enums;
using MediatR;

namespace Business.Handlers.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public CustomerType? CustomerType { get; set; }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;          

            public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
            { 
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer customer = await _unitOfWork.CustomerRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.CustomerRepository.UpdateAsync(customer);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CustomerUpdated);
            }
        }
    }
}