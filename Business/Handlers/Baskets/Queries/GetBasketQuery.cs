using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Baskets;
using MediatR;

namespace Business.Handlers.Baskets.Queries
{
    public class GetBasketQuery : IRequest<IDataResult<BasketDto>>
    {
        public Guid Id { get; set; }

        public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, IDataResult<BasketDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetBasketQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
            {
                var basket = await _unitOfWork.BasketRepository.GetAsync(a => a.Id == request.Id);
                var basketDto = _mapper.Map<BasketDto>(basket);
                return new SuccessDataResult<BasketDto>(basketDto);
            }
        }
    }
}
