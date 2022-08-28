using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Baskets.Commands
{
    public class DeleteBasketCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteBasketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
            {
                Basket basket = await _unitOfWork.BasketRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.BasketRepository.DeleteAsync(basket);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BasketDeleted);
            }
        }
    }
}
