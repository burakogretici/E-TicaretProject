using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Baskets;
using Core.Utilities.Results;
using MediatR;

namespace Business.Handlers.Baskets.Commands
{
    public class DeleteBasketCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, IResult>
        {
            private readonly IBasketService _basketService;
            public DeleteBasketCommandHandler( IBasketService basketService)
            {
                _basketService = basketService;
            }

            public async Task<IResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
            {
                var result= await _basketService.RemoveItemFromBasket(request.Id);
                return result;
            }
        }
    }
}
