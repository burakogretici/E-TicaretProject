using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Cities;
using Business.Services.Products;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Cities;
using MediatR;

namespace Business.Handlers.Cities.Queries
{
    public class GetCitiesTableQuery : IRequest<PaginatedResult<CityListDto>>
    {
        public TableGlobalFilter TableGlobalFilter { get; set; }
        public class GetCitiesTableQueryHandler : IRequestHandler<GetCitiesTableQuery, PaginatedResult<CityListDto>>
        {
            private readonly ICityService _cityService;

            public GetCitiesTableQueryHandler(ICityService cityService)
            {
                _cityService = cityService;
            }

            public async Task<PaginatedResult<CityListDto>> Handle(GetCitiesTableQuery request, CancellationToken cancellationToken)
            {
                var cityList = await _cityService.GetTableSearch(request.TableGlobalFilter);
                return cityList;
            }
        }
    }
}
