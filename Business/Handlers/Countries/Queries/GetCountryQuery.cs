using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Countries;
using Core.Utilities.Results;
using Entities.Dtos.Countries;
using MediatR;

namespace Business.Handlers.Countries.Queries
{
    public class GetCountryQuery : IRequest<IDataResult<CountryDto>>
    {
        public Guid Id { get; set; }

        public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, IDataResult<CountryDto>>
        {
            private readonly ICountryService _countryService;

            public GetCountryQueryHandler(ICountryService countryService)
            {
                _countryService = countryService;
            }
            public async Task<IDataResult<CountryDto>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
            {
                var country = await _countryService.GetByIdAsync(request.Id);
                return country;
            }
        }
    }
}
