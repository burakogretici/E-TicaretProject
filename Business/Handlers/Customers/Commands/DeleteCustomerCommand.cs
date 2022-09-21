using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;    

            public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
            {           
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer customer = await _unitOfWork.CustomerRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.CustomerRepository.DeleteAsync(customer);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CustomerDeleted);
            }
        }
    }
}
