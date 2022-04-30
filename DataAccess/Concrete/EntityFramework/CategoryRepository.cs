using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class CategoryRepository : EfEntityRepositoryBase<Category, EticaretContext>, ICategoryRepository
    {
        public CategoryRepository(EticaretContext context) : base(context)
        {
        }
    }
}
