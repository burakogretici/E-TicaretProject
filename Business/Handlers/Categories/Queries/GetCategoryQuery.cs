using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Categories;
using MediatR;

namespace Business.Handlers.Categories.Queries
{
    public class GetCategoryQuery : IRequest<IDataResult<CategoryDto>>
    {
        public Guid Id { get; set; }

        public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, IDataResult<CategoryDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _unitOfWork.CategoryRepository.GetAsync(a => a.Id == request.Id);
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return new SuccessDataResult<CategoryDto>(categoryDto);
            }
        }
    }
}
