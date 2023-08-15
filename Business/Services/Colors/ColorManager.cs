using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Business.Constants;
using Business.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Colors;

namespace Business.Services.Colors
{
    public class ColorManager : ServiceBase, IColorService
    {
        private readonly ColorRules _colorRules;
        public ColorManager(IServiceProvider serviceProvider, ColorRules colorRules) : base(serviceProvider)
        {
            _colorRules = colorRules;
        }
        //[SecuredOperation("Color.Add,Admin")]
        public async Task<IDataResult<ColorDto>> AddAsync(ColorDto colorDto)
        {
            await _colorRules.ColorNameAlreadyExists(colorDto.Name);

            var mapper = _mapper.Map<Color>(colorDto);
            await _unitOfWork.ColorRepository.AddAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessDataResult<ColorDto>(colorDto, Messages.ColorAdded);

        }
        [SecuredOperation("Color.Update,Admin")]
        public async Task<IResult> UpdateAsync(ColorDto colorDto)
        {
            var color = await GetByIdAsync(colorDto.Id);

            await _colorRules.ColorNameAlreadyExists(colorDto.Name);
            colorDto.CreatedDate = color.Data.CreatedDate;

            var mapper = _mapper.Map<Color>(colorDto);
            await _unitOfWork.ColorRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.ColorUpdated);

        }
        [SecuredOperation("Color.Delete,Admin")]
        public async Task<IResult> DeleteAsync(ColorDto colorDto)
        {
            var color = await GetByIdAsync(colorDto.Id);

            var mapper = _mapper.Map<Color>(color.Data);
            await _unitOfWork.ColorRepository.DeleteAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.ColorDeleted);

        }
        [SecuredOperation("Color.List,Admin")]
        public async Task<IDataResult<IEnumerable<ColorDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.ColorRepository.GetAllAsync(expression: x => x.Deleted != true,
                selector: x => new ColorDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.Name));

            return new SuccessDataResult<IEnumerable<ColorDto>>(result, Messages.ColorsListed);
        }

        public async Task<IDataResult<ColorDto>> GetByIdAsync(Guid colorId)
        {
            var result = await _unitOfWork.ColorRepository.GetAsync(br => br.Id == colorId);
            if (result == null) throw new BusinessException(Messages.ColorNotFound);

            var mapper = _mapper.Map<ColorDto>(result);
            return new SuccessDataResult<ColorDto>(mapper);         
        }

        public async Task<PaginatedResult<ColorDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter)
        {
            var colors = await _unitOfWork.ColorRepository.GetListForTableSearch(tableGlobalFilter);
            var mapped = _mapper.Map<PaginatedResult<ColorDto>>(colors);
            return mapped;
        }
    }
}