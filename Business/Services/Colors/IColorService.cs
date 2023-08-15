using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Dtos.Colors;

namespace Business.Services.Colors
{
    public interface IColorService
    {
        Task<IDataResult<ColorDto>> AddAsync(ColorDto colorDto);
        Task<IResult> UpdateAsync(ColorDto colorDto);
        Task<IResult> DeleteAsync(ColorDto colorDto);

        Task<IDataResult<IEnumerable<ColorDto>>> GetAllAsync();
        Task<PaginatedResult<ColorDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter);

        Task<IDataResult<ColorDto>> GetByIdAsync(Guid id);
    }
}