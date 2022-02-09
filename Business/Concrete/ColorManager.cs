using System.Collections.Generic;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

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

        public IDataResult<ColorDto> Add(ColorDto color)
        {
            //IResult result = BusinessRules.Run(ColorNameAlreadyExists(color.Name));
            //if (result != null)
            //{
            //    return result;
            //},
            var mapper = _mapper.Map<Color>(color);
            _colorDal.Add(mapper);
            return new SuccessDataResult<ColorDto>(color,Messages.ColorAdded);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<IEnumerable<ColorDto>> GetAll()
        {
            var result = _colorDal.GetAll();
            var mapper = _mapper.Map<List<ColorDto>>(result);
            return new SuccessDataResult<IEnumerable<ColorDto>>(mapper,Messages.ColorsListed);
        }

        public IDataResult<ColorDto> GetById(int colorId)
        {

            var result = _colorDal.Get(cl => cl.Id == colorId);
            var mapper = _mapper.Map<ColorDto>(result);
            return new SuccessDataResult<ColorDto>(mapper);
        }

        private IResult ColorNameAlreadyExists(string colorName)
        {
            var result = _colorDal.GetAll(c => c.Name == colorName);
            if (result == null)
            {
                return new ErrorResult(Messages.ColorNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
