using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Categories;
using Core.Utilities.Results;
using Entities.Dtos.Categories;
using MediatR;

namespace Business.Handlers.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IResult>
        {            
            private readonly IMapper _mapper;
            private readonly ICategoryService _categoryService;

            public CreateCategoryCommandHandler(IMapper mapper, ICategoryService categoryService) 
            {
                _categoryService = categoryService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<CategoryDto>(request);
                var category = await _categoryService.AddAsync(mapper);
                return category;
            }
        }
    }
}
