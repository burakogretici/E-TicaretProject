using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Baskets;
using MediatR;

namespace Business.Handlers.BasketItems.Queries
{
    public class GetBasketItemsQuery : IRequest<IDataResult<IEnumerable<BasketListDto>>>
    {
        public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQuery, IDataResult<IEnumerable<BasketListDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetBasketItemsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<BasketListDto>>> Handle(GetBasketItemsQuery request, CancellationToken cancellationToken)
            {
                var basketDetailList = await _unitOfWork.BasketItemRepository.GetAllAsync(
                    selector: x => new BasketListDto
                    {
                        Id = x.Id,
                        CustomerName = x.Basket.User.FirstName + " " + x.Basket.User.LastName,
                        ProductName = x.Product.Name,
                        Amount = x.Amount,
                    }
                );

                return new SuccessDataResult<IEnumerable<BasketListDto>>(basketDetailList);
            }
        }
    }
}
