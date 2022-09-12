using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Categories;
using Core.Utilities.Results;
using Entities.Dtos.Categories;
using MediatR;

namespace Business.Handlers.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IResult>
        {
            private readonly ICategoryService _categoryService;
            private readonly IMapper _mapper;
            public UpdateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
            {
                _categoryService = categoryService;
                _mapper = mapper;
            }
            public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<CategoryDto>(request);
                var category = await _categoryService.UpdateAsync(mapper);
                return category;

            }
        }
    }
}
