using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Brands;
using MediatR;


namespace Business.Handlers.Brands.Queries
{
    public class GetBrandsQuery : IRequest<IDataResult<IEnumerable<BrandDto>>>
    {
        public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IDataResult<IEnumerable<BrandDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetBrandsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<BrandDto>>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
            {
                var brandList = await _unitOfWork.BrandRepository.GetAllAsync(
                    selector: x => new BrandDto
                    {
                        Id = x.Id,
                        Name = x.Name
                    },
                    orderBy: x => x.OrderBy(x => x.Name));

                return new SuccessDataResult<IEnumerable<BrandDto>>(brandList);

            }
        }

    }
}
