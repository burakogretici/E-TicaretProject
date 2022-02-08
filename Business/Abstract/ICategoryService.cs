using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService 
    {
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);

        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int id);
    }
}
