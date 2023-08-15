using Core.Utilities.Results;
using Entities.Dtos.Menus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Menus
{
    public interface IMenuService
    {
        Task<IDataResult<MenuDto>> AddAsync(MenuDto menuDto);
        Task<IResult> UpdateAsync(MenuDto menuDto);
        Task<IResult> DeleteAsync(MenuDto menuDto);

        Task<IDataResult<IEnumerable<MenuDto>>> GetAllAsync();
        Task<IDataResult<IEnumerable<MenuDto>>> GetAllByParentMenuAsync(int parentMenuId);
        Task<IDataResult<MenuDto>> GetByIdAsync(int id);

    }
}
