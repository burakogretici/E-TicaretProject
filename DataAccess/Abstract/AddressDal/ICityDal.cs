using Core.DataAccess.Abstract;
using Entities.Concrete;


namespace DataAccess.Abstract.AddressDal
{
    public interface ICityDal : IEntityRepository<City>, IEntityAsyncRepository<City>
    {
    }
}
