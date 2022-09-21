using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.OrderDetails.Commands
{
    public class DeleteOrderDetailCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
           
            public DeleteOrderDetailCommandHandler( IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
            {
                OrderDetail orderDetail = await _unitOfWork.OrderDetailRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.OrderDetailRepository.DeleteAsync(orderDetail);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.OrderDeleted);
            }
        }
    }
}

