using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Countries;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Countries;
using MediatR;

namespace Business.Handlers.Countries.Queries
{
    public class GetCountriesTableQuery : IRequest<PaginatedResult<CountryDto>>
    {
        public TableGlobalFilter TableGlobalFilter { get; set; }
        public class GetCountriesTableQueryHandler : IRequestHandler<GetCountriesTableQuery, PaginatedResult<CountryDto>>
        {
            private readonly ICountryService _countryService;

            public GetCountriesTableQueryHandler(ICountryService countryService)
            {
                _countryService = countryService;
            }

            public async Task<PaginatedResult<CountryDto>> Handle(GetCountriesTableQuery request, CancellationToken cancellationToken)
            {
                var countryList = await _countryService.GetTableSearch(request.TableGlobalFilter);
                return countryList;
            }
        }
    }
}
