using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Orders.Commands
{
    public class DeleteOrderCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
       

        public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Order>(request);
                await _unitOfWork.OrderRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.OrderDeleted);
            }
        }
    }
}
