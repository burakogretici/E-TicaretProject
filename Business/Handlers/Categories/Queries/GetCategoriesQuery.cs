using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Categories;
using Core.Utilities.Results;
using Entities.Dtos.Categories;
using MediatR;

namespace Business.Handlers.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IDataResult<IEnumerable<CategoryDto>>>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IDataResult<IEnumerable<CategoryDto>>>
        {
            private readonly ICategoryService _categoryService;

            public GetCategoriesQueryHandler(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<IDataResult<IEnumerable<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
            {
                var categoryList = await _categoryService.GetAllAsync();
                return categoryList;
            }
        }
    }
}
