using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Baskets;
using MediatR;

namespace Business.Handlers.BasketItems.Queries
{
    public class GetBasketItemQuery : IRequest<IDataResult<BasketDto>>
    {
        public Guid BasketId { get; set; }

        public class GetBasketQueryHandler : IRequestHandler<GetBasketItemQuery, IDataResult<BasketDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetBasketQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<BasketDto>> Handle(GetBasketItemQuery request, CancellationToken cancellationToken)
            {
                var basket = await _unitOfWork.BasketItemRepository.GetAsync(a => a.Id == request.BasketId);
                var basketDto = _mapper.Map<BasketDto>(basket);
                return new SuccessDataResult<BasketDto>(basketDto);
            }

        }
    }
}
