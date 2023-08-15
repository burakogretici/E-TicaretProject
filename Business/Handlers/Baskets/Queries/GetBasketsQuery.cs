using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Baskets;
using MediatR;

namespace Business.Handlers.Baskets.Queries
{
    public class GetBasketsQuery : IRequest<IDataResult<IEnumerable<BasketListDto>>>
    {
        public class GetBasketsQueryHandler : IRequestHandler<GetBasketsQuery, IDataResult<IEnumerable<BasketListDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetBasketsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<BasketListDto>>> Handle(GetBasketsQuery request, CancellationToken cancellationToken)
            {
                var basketList = await _unitOfWork.BasketRepository.GetAllAsync(
                    selector: x => new BasketListDto
                    {
                        Id = x.Id,
                        CustomerName = x.User.FirstName + " " + x.User.LastName,
                    }
                );
                return new SuccessDataResult<IEnumerable<BasketListDto>>(basketList);
            }
        }
    }
}
