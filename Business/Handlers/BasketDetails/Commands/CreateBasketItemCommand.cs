using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Business.Services.Baskets;
using Business.Services.Brands;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Dtos.Baskets;
using Entities.Dtos.Brands;
using MediatR;

namespace Business.Handlers.BasketItems.Commands
{
    public class CreateBasketItemCommand : IRequest<IResult>
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public float Amount { get; set; }
        //public float Price { get; set; }
        //public float Total { get; set; }

        public class CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemCommand, IResult>
        {
            private readonly IBasketService _basketService;
            private readonly IMapper _mapper;

            public CreateBasketItemCommandHandler(IMapper mapper ,IBasketService basketService)
            {
                _mapper = mapper;
                _basketService = basketService;
            }

            public async Task<IResult> Handle(CreateBasketItemCommand request, CancellationToken cancellationToken)
            {   
                var mapper = _mapper.Map<BasketItemDto>(request);
                var basket = await _basketService.AddItemToBasket(mapper);
                return basket;
            }
        }
    }
}
