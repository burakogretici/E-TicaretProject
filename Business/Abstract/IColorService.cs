using System.Collections.Generic;
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

        IDataResult<IEnumerable<ColorDto>> GetAll();
        IDataResult<ColorDto> GetById(int colorId);
    }
}
