using System.Collections.Generic;
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

        IDataResult<IEnumerable<CityDto>> GetAll();
        IDataResult<CityDto> GetById(int id);
        IDataResult<IEnumerable<CityDto>> GetAllByCountry(int countryId);
    }
}
