using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Brands;
using Core.Utilities.Results;
using Entities.Dtos.Brands;
using MediatR;

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
