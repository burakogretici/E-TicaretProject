using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class ColorRepository : EfEntityRepositoryBase<Color,EticaretContext>,IColorRepository
    {
        public ColorRepository(EticaretContext context) : base(context)
        {
        }
    }
}
