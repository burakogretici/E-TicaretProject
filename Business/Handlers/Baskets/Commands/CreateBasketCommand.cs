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
    public class CreateBasketCommand : IRequest<IResult>
    {
        public Guid CustomerId { get; set; }
        public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateBasketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Basket>(request);
                await _unitOfWork.BasketRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BasketAdded);
            }
        }
    }
}
