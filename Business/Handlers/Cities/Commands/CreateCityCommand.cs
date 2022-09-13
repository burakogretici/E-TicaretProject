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
    public class CreateCityCommand : IRequest<IResult>
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }

        public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateCityCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<City>(request);
                await _unitOfWork.CityRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CityAdded);
            }
        }
    }
}