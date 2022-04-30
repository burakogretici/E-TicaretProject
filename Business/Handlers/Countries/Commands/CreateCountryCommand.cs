using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Countries.Commands
{
    public class CreateCountryCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public class CreateCountryCommandHandler:IRequestHandler<CreateCountryCommand,IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateCountryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Country>(request); 
                await _unitOfWork.CountryRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CountryAdded);
            }
        }
    }
}
