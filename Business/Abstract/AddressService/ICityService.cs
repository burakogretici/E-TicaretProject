using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;


namespace Business.Abstract.AddressService
{
    public interface ICityService
    {
        IResult Add(City city);
        IResult Update(City city); 
        IResult Delete(City city);

        IDataResult<List<City>> GetAll();
        IDataResult<City> GetById(int id);
        IDataResult<List<City>> GetAllByCountry(int countryId);
    }
}
