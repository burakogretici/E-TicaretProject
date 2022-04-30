using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Countries;
using MediatR;

namespace Business.Handlers.Countries.Queries
{
    public class GetCountryQuery : IRequest<IDataResult<CountryDto>>
    {
        public Guid Id { get; set; }

        public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, IDataResult<CountryDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetCountryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<CountryDto>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
            {
                var country = await _unitOfWork.CountryRepository.GetAsync(a => a.Id == request.Id);
                var countryDto = _mapper.Map<CountryDto>(country);
                return new SuccessDataResult<CountryDto>(countryDto);
            }
        }
    }
}
