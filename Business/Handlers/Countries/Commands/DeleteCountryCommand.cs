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
    public class DeleteCountryCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteCountryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Country>(request);
                await _unitOfWork.CountryRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CountryDeleted);
            }
        }
    }
}
