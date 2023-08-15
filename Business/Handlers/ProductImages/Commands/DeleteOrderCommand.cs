//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Business.Constants;
//using Core.Utilities.Results;
//using DataAccess.UnitOfWork;
//using Entities.Concrete;
//using MediatR;

//namespace Business.Handlers.Orders.Commands
//{
//    public class DeleteOrderCommand : IRequest<IResult>
//    {
//        public Guid Id { get; set; }

//        public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, IResult>
//        {
//            private readonly IUnitOfWork _unitOfWork;          

//            public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
//            {              
//                _unitOfWork = unitOfWork;
//            }

//            public async Task<IResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
//            {
//                Order order = await _unitOfWork.OrderRepository.GetAsync(x => x.Id == request.Id);
//                await _unitOfWork.OrderRepository.DeleteAsync(order);
//                await _unitOfWork.Commit();
//                return new SuccessResult(Messages.OrderDeleted);
//            }
//        }
//    }
//}
