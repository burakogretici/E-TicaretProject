using Business.BusinessAspects;
using Business.Constants;
using Business.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Extensions;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Menus;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Menus
{
    public class MenuManager : ServiceBase, IMenuService
    {
        private readonly MenuRules _menuRules;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MenuManager(IServiceProvider serviceProvider, MenuRules menuRules, IHttpContextAccessor httpContextAccessor) : base(serviceProvider)
        {
            _menuRules = menuRules;
            _httpContextAccessor = httpContextAccessor;
        }
        //[SecuredOperation("Menu.Add,Admin")]
        public async Task<IDataResult<MenuDto>> AddAsync(MenuDto menuDto)
        {
            var mapper = _mapper.Map<Menu>(menuDto);
            await _unitOfWork.MenuRepository.AddAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessDataResult<MenuDto>(menuDto, Messages.MenuAdded);

        }
        [SecuredOperation("Menu.Delete,Admin")]
        public async Task<IResult> DeleteAsync(MenuDto menuDto)
        {
            var menu = await GetByIdAsync(menuDto.Id);

            var mapper = _mapper.Map<Menu>(menu.Data);
            await _unitOfWork.MenuRepository.DeleteAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessResult(Messages.MenuDeleted);

        }
        [SecuredOperation("Menu.Update,Admin")]
        public async Task<IResult> UpdateAsync(MenuDto menuDto)
        {
            var menu = await GetByIdAsync(menuDto.Id);
            //menuDto.CreatedDate = menu.Data.CreatedDate;

            var mapper = _mapper.Map<Menu>(menuDto);
            await _unitOfWork.MenuRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.MenuUpdated);

        }
        //[SecuredOperation("Menu.List")]
        //[CacheAspect()]
        public async Task<IDataResult<IEnumerable<MenuDto>>> GetAllAsync()
        {
            var result = new List<MenuDto>();

            var query = await _unitOfWork.MenuRepository.GetAllAsync(expression: x => x.Hidden != true, selector: x => new MenuDto
            {
                Id = x.Id,
                Name = x.Name,
                ParentMenuId = x.ParentMenuId,
                ParentMenu = x.ParentMenu.Name,
                Url = x.Url,
                Icon = x.Icon,
                Hidden = x.Hidden,
                IsAdmin = x.IsAdmin,
                DisplayOrder = x.DisplayOrder,
                //CreatedDate = x.CreatedDate,
                //UpdatedDate = x.UpdatedDate,
                //Deleted = x.Deleted,
            },
                orderBy: x => x.OrderBy(x => x.DisplayOrder));
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            if (roleClaims.Contains("Admin"))
            {
                result = query;
            }
            else
            {
                result = query.Where(x => x.IsAdmin != true).ToList();
            }
            
            return new SuccessDataResult<IEnumerable<MenuDto>>(result, Messages.MenuListed);
        }

        public async Task<IDataResult<IEnumerable<MenuDto>>> GetAllByParentMenuAsync(int parentMenuId)
        {
            var result = await _unitOfWork.MenuRepository.GetAllAsync(expression: x => x.Deleted != true && x.ParentMenuId == parentMenuId && x.Hidden != true,
                selector: x => new MenuDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentMenuId = x.ParentMenuId,
                    Url = x.Url,
                    Icon = x.Icon,
                    Hidden = x.Hidden,
                    DisplayOrder = x.DisplayOrder,
                    //CreatedDate = x.CreatedDate,
                    //UpdatedDate = x.UpdatedDate,
                    //Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.DisplayOrder));

            return new SuccessDataResult<IEnumerable<MenuDto>>(result, Messages.MenuListed);
        }

        [SecuredOperation("Menu.Get,Admin")]
        public async Task<IDataResult<MenuDto>> GetByIdAsync(int menuId)
        {
            var result = await _unitOfWork.MenuRepository.GetAsync(br => br.Id == menuId);
            if (result == null) throw new BusinessException(Messages.MenuNotFound);

            var mapper = _mapper.Map<MenuDto>(result);
            return new SuccessDataResult<MenuDto>(mapper);
        }
    }
}
