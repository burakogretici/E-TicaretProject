using Business.Services.Brands;
using Business.Services.Colors;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Brands;
using Entities.Dtos.Colors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Brands.Queries
{
    public class GetBrandsQuery : IRequest<IDataResult<IEnumerable<BrandDto>>>
    {
        public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IDataResult<IEnumerable<BrandDto>>>
        {
            private readonly IBrandService _brandService;

            public GetBrandsQueryHandler(IBrandService brandService)
            {
                _brandService = brandService;
            }

            public async Task<IDataResult<IEnumerable<BrandDto>>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
            {          
                var brandList = await _brandService.GetAllAsync();
                return brandList;
            }
        }
    }
}


