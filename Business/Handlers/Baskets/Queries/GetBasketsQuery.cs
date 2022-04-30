using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Baskets;
using MediatR;

namespace Business.Handlers.Baskets.Queries
{
    public class GetBasketsQuery : IRequest<IDataResult<IEnumerable<BasketDto>>>
    {
        public class GetBasketsQueryHandler : IRequestHandler<GetBasketsQuery, IDataResult<IEnumerable<BasketDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetBasketsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<BasketDto>>> Handle(GetBasketsQuery request, CancellationToken cancellationToken)
            {
                var basketList = await _unitOfWork.BasketRepository.GetAllAsync(
                    selector: x => new BasketDto
                    {
                        Id = x.Id,
                        CustomerName = x.Customer.User.FirstName + " " + x.Customer.User.LastName,
                        //ProductName = x.Product.Name,
                        //Amount = x.Amount,
                        //Price = x.Price,
                        //Total = x.Total
                    }
                );
                return new SuccessDataResult<IEnumerable<BasketDto>>(basketList);
            }
        }
    }
}
