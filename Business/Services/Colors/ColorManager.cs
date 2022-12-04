using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Business.Rules;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Dtos.Colors;


namespace Business.Services.Colors
{
    public class ColorManager : IColorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ColorRules _colorRules;
        public ColorManager(IMapper mapper, IUnitOfWork unitOfWork, ColorRules colorRules)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _colorRules = colorRules;
        }

        public async Task<IDataResult<ColorDto>> AddAsync(ColorDto colorDto)
        {
            IResult result = BusinessRules.Run(await _colorRules.ColorNameAlreadyExists(colorDto.Name));
            if (result == null)
            {
                var mapper = _mapper.Map<Color>(colorDto);
                await _unitOfWork.ColorRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessDataResult<ColorDto>(colorDto, Messages.ColorAdded);
            }

            return new ErrorDataResult<ColorDto>(result.Message);
        }

        public async Task<IResult> UpdateAsync(ColorDto colorDto)
        {
            IResult result = BusinessRules.Run(await _colorRules.ColorNameAlreadyExists(colorDto.Name));
            if (result == null)
            {
                var mapper = _mapper.Map<Color>(colorDto);
                await _unitOfWork.ColorRepository.UpdateAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.ColorUpdated);
            }
            return new ErrorResult(result.Message);

        }

        public async Task<IResult> DeleteAsync(ColorDto colorDto)
        {
            var color = await GetByIdAsync(colorDto.Id);
            if (color.Data != null)
            {
                var mapper = _mapper.Map<Color>(color.Data);
                await _unitOfWork.ColorRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.ColorDeleted);
            }
            return color;
        }

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
            if (result == null)
            {
                return new ErrorDataResult<ColorDto>(Messages.ColorNotFound);
            }
            var mapper = _mapper.Map<ColorDto>(result);
            return new SuccessDataResult<ColorDto>(mapper);
        }
    }
}