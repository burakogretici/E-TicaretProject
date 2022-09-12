using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Categories;
using Core.Utilities.Results;
using Entities.Dtos.Categories;
using MediatR;

namespace Business.Handlers.Categories.Queries
{
    public class GetCategoryQuery : IRequest<IDataResult<CategoryDto>>
    {
        public Guid Id { get; set; }

        public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, IDataResult<CategoryDto>>
        {
            private readonly ICategoryService _categoryService;

            public GetCategoryQueryHandler(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<IDataResult<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _categoryService.GetByIdAsync(request.Id);
                return category;
            }
        }
    }
}
