
using Business.Services.Products;
using Core.Utilities.Results;

using Entities.Dtos.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Queries
{
    public class GetProductsQuery : IRequest<IDataResult<IEnumerable<ProductListDto>>>
    {
        public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IDataResult<IEnumerable<ProductListDto>>>
        {
            private readonly IProductService _productService;

            public GetProductsQueryHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<IDataResult<IEnumerable<ProductListDto>>> Handle(GetProductsQuery request,
                CancellationToken cancellationToken)
            {
                var productList = await _productService.GetAllAsync();
                return productList;
            }
        }
    }
}