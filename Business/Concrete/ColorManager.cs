﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Colors;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;
        private readonly IMapper _mapper;

        public ColorManager(IColorDal colorDal, IMapper mapper)
        {
            _colorDal = colorDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<ColorDto>> AddAsync(ColorDto color)
        {
            //IResult result = BusinessRules.Run(ColorNameAlreadyExists(color.Name));
            //if (result != null)
            //{
            //    return result;
            //},
            var mapper = _mapper.Map<Color>(color);
            await _colorDal.AddAsync(mapper);
            return new SuccessDataResult<ColorDto>(color,Messages.ColorAdded);
        }

        public async Task<IResult> UpdateAsync(Color color)
        {
            await _colorDal.UpdateAsync(color);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        public async Task<IResult> DeleteAsync(Color color)
        {
            await _colorDal.DeleteAsync(color);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public async Task<IDataResult<IEnumerable<ColorDto>>> GetAllAsync()
        {
            var result = await _colorDal.GetAllAsync();
            var mapper = _mapper.Map<List<ColorDto>>(result);
            return new SuccessDataResult<IEnumerable<ColorDto>>(mapper,Messages.ColorsListed);
        }

        public async Task<IDataResult<ColorDto>> GetByIdAsync(Guid colorId)
        {

            var result = await _colorDal.GetAsync(cl => cl.Id == colorId);
            var mapper = _mapper.Map<ColorDto>(result);
            return new SuccessDataResult<ColorDto>(mapper);
        }

     
    }
}
