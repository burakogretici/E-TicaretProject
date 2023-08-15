using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Products;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Products;
using MediatR;

namespace Business.Handlers.Products.Queries
{
    public class GetProductsQuery : IRequest<PaginatedResult<ProductListDto>>
    {
        public TableGlobalFilter TableGlobalFilter { get; set; }

        public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PaginatedResult<ProductListDto>>
        {
            private readonly IProductService _productService;

            public GetProductsQueryHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<PaginatedResult<ProductListDto>> Handle(GetProductsQuery request,
                CancellationToken cancellationToken)
            {
                var productList = await _productService.GetTableSearch(request.TableGlobalFilter);
                return productList;

            }
        }
    }
}