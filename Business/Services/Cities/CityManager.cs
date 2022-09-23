using AutoMapper;
using Business.Constants;
using Business.Rules;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Dtos.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Cities
{
    public class CityManager : ICityService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CityRules _cityRules;
        public CityManager(IMapper mapper, IUnitOfWork unitOfWork, CityRules cityRules)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cityRules = cityRules;
        }


        public async Task<IDataResult<CityDto>> AddAsync(CityDto cityDto)
        {
            IResult result = BusinessRules.Run(await _cityRules.CityNameAlreadyExists(cityDto.Name));
            if (result == null)
            {
                var mapper = _mapper.Map<City>(cityDto);
                await _unitOfWork.CityRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessDataResult<CityDto>(cityDto, Messages.CityAdded);
            }
            return new ErrorDataResult<CityDto>(result.Message);
        }

        public async Task<IResult> UpdateAsync(CityDto cityDto)
        {
            var city = await GetByIdAsync(cityDto.Id);
            if (city.Data != null)
            {
                IResult result = BusinessRules.Run(await _cityRules.CityNameAlreadyExists(cityDto.Name));
                if (result == null)
                {
                    city.Data.Name = cityDto.Name;
                    var mapper = _mapper.Map<City>(city.Data);
                    await _unitOfWork.CityRepository.UpdateAsync(mapper);
                    await _unitOfWork.Commit();
                    return new SuccessResult(Messages.CityUpdated);
                }

                return result;
            }
            return city;
        }

        public async Task<IResult> DeleteAsync(CityDto cityDto)
        {
            var city = await GetByIdAsync(cityDto.Id);
            if (city.Data != null)
            {
                var mapper = _mapper.Map<City>(city.Data);
                await _unitOfWork.CityRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CityDeleted);
            }

            return city;

        }

        public async Task<IDataResult<IEnumerable<CityDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.CityRepository.GetAllAsync(expression: x => x.Deleted != true,
                selector: x => new CityDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.Name));

            return new SuccessDataResult<IEnumerable<CityDto>>(result, Messages.CityListed);
        }

        public async Task<IDataResult<IEnumerable<CityDto>>> GetAllByCountryAsync(Guid countryId)
        {
            var result = await _unitOfWork.CityRepository.GetAllAsync(expression: x => x.Deleted != true,
                selector: x => new CityDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.Name));

            return new SuccessDataResult<IEnumerable<CityDto>>(result, Messages.CityListed);
        }

        public async Task<IDataResult<CityDto>> GetByIdAsync(Guid cityId)
        {
            var result = await _unitOfWork.CityRepository.GetAsync(br => br.Id == cityId);
            if (result == null)
            {
                return new ErrorDataResult<CityDto>(Messages.CityNotFound);
            }
            var mapper = _mapper.Map<CityDto>(result);
            return new SuccessDataResult<CityDto>(mapper);
        }
    }
}
