using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Colors;

namespace Business.Abstract
{
    public interface IColorService 
    {
        Task<IDataResult<ColorDto>> AddAsync(ColorDto color);
        Task<IResult> UpdateAsync(Color color);
        Task<IResult> DeleteAsync(Color color);

        Task<IDataResult<IEnumerable<ColorDto>>> GetAllAsync();
        Task<IDataResult<ColorDto>> GetByIdAsync(Guid id);
    }
}
