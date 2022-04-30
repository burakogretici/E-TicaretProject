using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
            private readonly IMapper _mapper;

            public DeleteOrderDetailCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<OrderDetail>(request);
                await _unitOfWork.OrderDetailRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.OrderDeleted);
            }
        }
    }
}

