using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Products;
using MediatR;

namespace Business.Handlers.Products.Queries
{
    public class GetProductQuery : IRequest<IDataResult<ProductDto>>
    {
        public Guid Id { get; set; }

        public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IDataResult<ProductDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(a => a.Id == request.Id);
                var productDto = _mapper.Map<ProductDto>(product);
                return new SuccessDataResult<ProductDto>(productDto);
            }
        }
    }
}
