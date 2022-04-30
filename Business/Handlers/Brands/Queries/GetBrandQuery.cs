using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Brands;
using MediatR;

namespace Business.Handlers.Brands.Queries
{
    public class GetBrandQuery : IRequest<IDataResult<BrandDto>>
    {
        public Guid Id { get; set; }

        public class GetUserQueryHandler : IRequestHandler<GetBrandQuery, IDataResult<BrandDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<BrandDto>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
            {
                var brand =  await _unitOfWork.BrandRepository.GetAsync(b => b.Id == request.Id);
                var brandDto = _mapper.Map<BrandDto>(brand);
                return new SuccessDataResult<BrandDto>(brandDto);
            }
        }
    }
}
