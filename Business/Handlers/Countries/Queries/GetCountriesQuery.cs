using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Countries;
using Core.Utilities.Results;
using Entities.Dtos.Countries;
using MediatR;

namespace Business.Handlers.Countries.Queries
{
    public class GetCountriesQuery : IRequest<IDataResult<IEnumerable<CountryDto>>>
    {
        public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IDataResult<IEnumerable<CountryDto>>>
        {
            private readonly ICountryService _countryService;

            public GetCountriesQueryHandler(ICountryService countryService)
            {
                _countryService = countryService;
            }

            public async Task<IDataResult<IEnumerable<CountryDto>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
            {
                var countryList = await _countryService.GetAllAsync();
                return countryList;
            }
        }
    }
}

