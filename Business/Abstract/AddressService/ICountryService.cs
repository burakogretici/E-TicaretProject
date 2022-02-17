using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Abstract.AddressService
{
    public interface ICountryService 
    {
        IDataResult<CountryDto> Add(CountryDto country);
        IResult Update(Country country);
        IResult Delete(Country country);

        Task<IDataResult<IEnumerable<CountryDto>>> GetAllAsync();
        Task<IDataResult<CountryDto>> GetByIdAsync(int id);
    }
}
