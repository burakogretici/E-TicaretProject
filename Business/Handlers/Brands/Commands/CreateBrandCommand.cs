using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
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

            public CreateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Brand>(request);
                await _unitOfWork.BrandRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.BrandAdded);
            }
        }
    }
}
