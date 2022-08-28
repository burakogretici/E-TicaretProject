using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Brands.Commands
{
    public class CreateBrandCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly BrandRules _brandRules;
            public CreateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,BrandRules brandRules)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _brandRules = brandRules;
            }

            public async Task<IResult> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                _brandRules.BrandNameAlreadyExists(request.Name);

                var mapper = _mapper.Map<Brand>(request);
            
                await _unitOfWork.BrandRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BrandAdded);
            }
        }
    }
}
