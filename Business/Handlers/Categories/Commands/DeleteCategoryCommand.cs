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
    public class DeleteCategoryCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IResult>
        {
            private readonly ICategoryService _categoryService;
            private readonly IMapper _mapper;

            public DeleteCategoryCommandHandler(ICategoryService categoryService,IMapper mapper)
            {
                _categoryService = categoryService;
                _mapper = mapper;
            }
         
            public async Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<CategoryDto>(request);             
                var category = await _categoryService.DeleteAsync(mapper);
                return category;
            }
        }
    }
}
