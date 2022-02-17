using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IColorService 
    {
        IDataResult<ColorDto> Add(ColorDto color);
        IResult Update(Color color);
        IResult Delete(Color color);

        Task<IDataResult<IEnumerable<ColorDto>>> GetAllAsync();
        Task<IDataResult<ColorDto>> GetByIdAsync(int id);
    }
}
