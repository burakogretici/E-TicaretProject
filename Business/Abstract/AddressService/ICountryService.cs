using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Countries;


namespace Business.Abstract.AddressService
{
    public interface ICountryService 
    {
        Task<IDataResult<CountryDto>> AddAsync(CountryDto country);
        Task<IResult> UpdateAsync(Country country);
        Task<IResult> DeleteAsync(Country country);

        Task<IDataResult<IEnumerable<CountryDto>>> GetAllAsync();
        Task<IDataResult<CountryDto>> GetByIdAsync(Guid id);
    }
}
