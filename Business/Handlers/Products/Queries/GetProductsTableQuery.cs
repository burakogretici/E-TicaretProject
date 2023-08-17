using System.Threading;
using System.Threading.Tasks;
using Business.Services.Products;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Products;
using MediatR;

namespace Business.Handlers.Products.Queries
{
    public class GetProductsTableQuery : IRequest<PaginatedResult<ProductListDto>>
    {
        public TableGlobalFilter TableGlobalFilter { get; set; }

        public class GetProductsQueryHandler : IRequestHandler<GetProductsTableQuery, PaginatedResult<ProductListDto>>
        {
            private readonly IProductService _productService;

            public GetProductsQueryHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<PaginatedResult<ProductListDto>> Handle(GetProductsTableQuery request,
                CancellationToken cancellationToken)
            {
                var productList = await _productService.GetTableSearch(request.TableGlobalFilter);
                return productList;

            }
        }
    }
}