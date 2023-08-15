using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Brands;
using Entities.Dtos.Countries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Countries
{
    public interface ICountryService
    {
        Task<IDataResult<CountryDto>> AddAsync(CountryDto countryDto);
        Task<IResult> UpdateAsync(CountryDto countryDto);
        Task<IResult> DeleteAsync(CountryDto countryDto);

        Task<IDataResult<IEnumerable<CountryDto>>> GetAllAsync();
        Task<IDataResult<CountryDto>> GetByIdAsync(Guid id);

        Task<PaginatedResult<CountryDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter);

    }
}
