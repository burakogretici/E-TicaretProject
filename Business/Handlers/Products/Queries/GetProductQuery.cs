using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Products;
using Core.Utilities.Results;
using Entities.Dtos.Products;
using MediatR;

namespace Business.Handlers.Products.Queries
{
    public class GetProductQuery : IRequest<IDataResult<ProductDto>>
    {
        public Guid Id { get; set; }

        public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IDataResult<ProductDto>>
        {
            private readonly IProductService _productService;

            public GetProductQueryHandler(IProductService productService)
            {
                _productService = productService;
            }


            public async Task<IDataResult<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var product = await _productService.GetByIdAsync(request.Id);
                return product;
            }
        }
    }
}
