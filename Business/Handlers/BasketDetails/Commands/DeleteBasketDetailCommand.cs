using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.BasketDetails.Commands
{
    public class DeleteBasketDetailCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
      
        public class DeleteBasketDetailCommandHandler : IRequestHandler<DeleteBasketDetailCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteBasketDetailCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(DeleteBasketDetailCommand request, CancellationToken cancellationToken)
            {
                BasketDetail basketDetail = await _unitOfWork.BasketDetailRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.BasketDetailRepository.DeleteAsync(basketDetail);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BasketDeleted);
            }
        }
    }
}
