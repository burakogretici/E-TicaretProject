using AutoMapper;
using Business.Constants;
using Business.Rules;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Dtos.Brands;
using Entities.Dtos.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Menus
{
    public class MenuManager : IMenuService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly MenuRules _menuRules;
        public MenuManager(IMapper mapper, IUnitOfWork unitOfWork, MenuRules menuRules)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _menuRules = menuRules;
        }

        public async Task<IDataResult<MenuDto>> AddAsync(MenuDto menuDto)
        {
            IResult result = BusinessRules.Run();
            if (result == null)
            {
                var mapper = _mapper.Map<Menu>(menuDto);

                await _unitOfWork.MenuRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessDataResult<MenuDto>(menuDto, Messages.MenuAdded);
            }
            return new ErrorDataResult<MenuDto>(result.Message);
        }

        public async Task<IResult> DeleteAsync(MenuDto menuDto)
        {
            var menu = await GetByIdAsync(menuDto.Id);
            if (menu.Data != null)
            {
                var mapper = _mapper.Map<Menu>(menu.Data);
                await _unitOfWork.MenuRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.MenuDeleted);
            }

            return menu;
        }

        public async Task<IResult> UpdateAsync(MenuDto menuDto)
        {
            IResult result = BusinessRules.Run();
            if (result == null)
            {         
                var mapper = _mapper.Map<Menu>(menuDto);
                await _unitOfWork.MenuRepository.UpdateAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.MenuUpdated);
            }

            return result;

        
        }
        public async Task<IDataResult<IEnumerable<MenuDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.MenuRepository.GetAllAsync(expression: x => x.Deleted != true && x.Hidden != true,
                selector: x => new MenuDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentMenuId = x.ParentMenuId,
                    ParentMenu = x.ParentMenu.Name,
                    Url = x.Url,
                    Icon = x.Icon,
                    Hidden = x.Hidden,
                    DisplayOrder = x.DisplayOrder,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.DisplayOrder));

            return new SuccessDataResult<IEnumerable<MenuDto>>(result, Messages.MenuListed);
        }

        public async Task<IDataResult<IEnumerable<MenuDto>>> GetAllByParentMenuAsync(Guid parentMenuId)
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
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.DisplayOrder));

            return new SuccessDataResult<IEnumerable<MenuDto>>(result, Messages.MenuListed);
        }

        public async Task<IDataResult<MenuDto>> GetByIdAsync(Guid menuId)
        {
            var result = await _unitOfWork.MenuRepository.GetAsync(br => br.Id == menuId);
            if (result == null)
            {
                return new ErrorDataResult<MenuDto>(Messages.MenuNotFound);
            }
            var mapper = _mapper.Map<MenuDto>(result);
            return new SuccessDataResult<MenuDto>(mapper);
        }
    }
}
