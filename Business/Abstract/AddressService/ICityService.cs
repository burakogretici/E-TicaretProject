using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Abstract.AddressService
{
    public interface ICityService
    {
        IDataResult<CityDto> Add(CityDto city);
        IResult Update(City city); 
        IResult Delete(City city);

        Task<IDataResult<IEnumerable<CityDto>>> GetAllAsync();
        Task<IDataResult<CityDto>> GetByIdAsync(int id);
        Task<IDataResult<IEnumerable<CityDto>>> GetAllByCountryAsync(int countryId);
    }
}
