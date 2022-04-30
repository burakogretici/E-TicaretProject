using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICountryRepository :  IEntityAsyncRepository<Country>
    {
    }
}
