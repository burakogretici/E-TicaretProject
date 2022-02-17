using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICategoryService 
    {
        IDataResult<CategoryDto> Add(CategoryDto category);
        IResult Update(Category category);
        IResult Delete(Category category);

        Task<IDataResult<IEnumerable<CategoryDto>>> GetAllAsync();
        Task<IDataResult<CategoryDto>> GetByIdAsync(int id);
    }
}
