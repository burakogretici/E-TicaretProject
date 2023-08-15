using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Brands;
using Business.Services.Categories;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Brands;
using Entities.Dtos.Categories;
using MediatR;

namespace Business.Handlers.Categories.Queries
{
    public class GetCategoriesTableQuery : IRequest<PaginatedResult<CategoryDto>>
    {
        public TableGlobalFilter TableGlobalFilter { get; set; }

        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesTableQuery, PaginatedResult<CategoryDto>>
        {
            private readonly ICategoryService _categoryService;

            public GetCategoriesQueryHandler(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<PaginatedResult<CategoryDto>> Handle(GetCategoriesTableQuery request, CancellationToken cancellationToken)
            {
                var categoryList = await _categoryService.GetTableSearch(request.TableGlobalFilter);
                return categoryList;
            }
        }
    }
}
