using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Handlers.Products.Queries;
using Business.Services.Baskets;
using Business.Services.Products;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using DataAccess.UnitOfWork;
using Entities.Dtos.Baskets;
using Entities.Dtos.Products;
using MediatR;

namespace Business.Handlers.BasketItems.Queries
{
    public class GetBasketItemsQuery : IRequest<PaginatedResult<BasketListDto>>
    {
        public TableGlobalFilter TableGlobalFilter { get; set; }

        public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQuery, PaginatedResult<BasketListDto>>
        {
            private readonly IBasketService _basketService;

            public GetBasketItemsQueryHandler(IBasketService basketService)
            {
                _basketService = basketService;
            }

            public async Task<PaginatedResult<BasketListDto>> Handle(GetBasketItemsQuery request, CancellationToken cancellationToken)
            {
                var basketItemList = await _basketService.GetTableSearch(request.TableGlobalFilter);
                return basketItemList;
            }
        }
    }
}
