using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Cities.Commands
{
    public class DeleteCityCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        
        public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<City>(request);
                await _unitOfWork.CityRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CityDeleted);
            }
        }
    }
}
