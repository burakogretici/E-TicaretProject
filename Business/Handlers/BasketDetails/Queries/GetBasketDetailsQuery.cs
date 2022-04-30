using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Baskets;
using MediatR;

namespace Business.Handlers.BasketDetails.Queries
{
    public class GetBasketDetailsQuery : IRequest<IDataResult<IEnumerable<BasketDto>>>
    {
        public class GetBasketDetailsQueryHandler : IRequestHandler<GetBasketDetailsQuery, IDataResult<IEnumerable<BasketDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetBasketDetailsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<BasketDto>>> Handle(GetBasketDetailsQuery request, CancellationToken cancellationToken)
            {
                var basketDetailList = await _unitOfWork.BasketDetailRepository.GetAllAsync(
                    selector: x => new BasketDto
                    {
                        Id = x.Id,
                        CustomerName = x.Basket.Customer.User.FirstName + " " + x.Basket.Customer.User.LastName,
                        ProductName = x.Product.Name,
                        Amount = x.Amount,
                        Price = x.Price,
                        Total = x.Total
                    }
                );
                return new SuccessDataResult<IEnumerable<BasketDto>>(basketDetailList);
            }
        }
    }
}
