using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.BasketItems.Commands
{
    public class DeleteBasketItemCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
      
        public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteBasketItemCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
            {
                BasketItem basketDetail = await _unitOfWork.BasketItemRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.BasketItemRepository.DeleteAsync(basketDetail);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BasketDeleted);
            }
        }
    }
}
