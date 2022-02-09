using System.Collections.Generic;
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

        IDataResult<IEnumerable<CountryDto>> GetAll();
        IDataResult<CountryDto> GetById(int id);
    }
}
