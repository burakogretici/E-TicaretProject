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
                var mapper = _mapper.Map<BasketDetail>(request);
                await _unitOfWork.BasketDetailRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BasketDeleted);
            }
        }
    }
}
