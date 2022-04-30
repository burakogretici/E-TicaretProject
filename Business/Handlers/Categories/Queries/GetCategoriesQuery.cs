using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Categories;
using MediatR;

namespace Business.Handlers.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IDataResult<IEnumerable<CategoryDto>>>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IDataResult<IEnumerable<CategoryDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetCategoriesQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
            {
                var categoryList = await _unitOfWork.CategoryRepository.GetAllAsync(
                    selector: x => new CategoryDto
                    {
                        Id = x.Id,
                        Name = x.Name
                    },
                    orderBy: x => x.OrderBy(x => x.Name));

                return new SuccessDataResult<IEnumerable<CategoryDto>>(categoryList);

            }
        }
    }
}
