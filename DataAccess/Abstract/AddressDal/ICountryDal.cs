using Core.DataAccess.Abstract;
using Entities.Concrete;


namespace DataAccess.Abstract.AddressDal
{
    public interface ICountryDal : IEntityRepository<Country>, IEntityAsyncRepository<Country>
    {
    }
}
