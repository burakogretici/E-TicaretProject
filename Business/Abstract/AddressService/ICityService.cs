using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Cities;


namespace Business.Abstract.AddressService
{
    public interface ICityService
    {
        Task<IDataResult<CityDto>> AddAsync(CityDto city);
        Task<IResult> UpdateAsync(City city); 
        Task<IResult> DeleteAsync(City city);

        Task<IDataResult<IEnumerable<CityDto>>> GetAllAsync();
        Task<IDataResult<CityDto>> GetByIdAsync(Guid id);
        Task<IDataResult<IEnumerable<CityDto>>> GetAllByCountryAsync(Guid countryId);
    }
}
