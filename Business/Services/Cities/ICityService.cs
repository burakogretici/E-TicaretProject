using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Brands;
using Entities.Dtos.Cities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Cities
{
    public interface ICityService
    {
        Task<IDataResult<CityDto>> AddAsync(CityDto cityDto);
        Task<IResult> UpdateAsync(CityDto cityDto);
        Task<IResult> DeleteAsync(CityDto cityDto);

        Task<IDataResult<IEnumerable<CityDto>>> GetAllAsync();
        Task<IDataResult<CityDto>> GetByIdAsync(Guid id);
        Task<IDataResult<IEnumerable<CityDto>>> GetAllByCountryAsync(Guid countryId);

        Task<PaginatedResult<CityListDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter);

    }
}
