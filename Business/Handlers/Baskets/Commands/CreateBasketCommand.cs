using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Business.Services.Baskets;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Dtos.Baskets;
using MediatR;

namespace Business.Handlers.Baskets.Commands
{
    public class CreateBasketCommand : IRequest<IResult>
    {
        public Guid UserId { get; set; }

        public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly IBasketService _basketService;


            public CreateBasketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IBasketService basketService )
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _basketService = basketService;
            }

            public async Task<IResult> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<BasketDto>(request);
                var basket = await _basketService.CreateBasket(mapper);
                return basket;
            }
        }
    }
}
