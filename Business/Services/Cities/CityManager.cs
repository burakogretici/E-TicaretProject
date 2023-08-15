using Business.Constants;
using Business.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Services.Cities
{
    public class CityManager : ServiceBase, ICityService
    {
        private readonly CityRules _cityRules;
        public CityManager(IServiceProvider serviceProvider, CityRules cityRules) : base(serviceProvider)
        {
            _cityRules = cityRules;
        }

        public async Task<IDataResult<CityDto>> AddAsync(CityDto cityDto)
        {
            await _cityRules.CityNameAlreadyExists(cityDto.Name);

            var mapper = _mapper.Map<City>(cityDto);
            await _unitOfWork.CityRepository.AddAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessDataResult<CityDto>(cityDto, Messages.CityAdded);

        }

        public async Task<IResult> UpdateAsync(CityDto cityDto)
        {

            await _cityRules.CityNameAlreadyExists(cityDto.Name);

            var city = await GetByIdAsync(cityDto.Id);
            cityDto.CreatedDate = city.Data.CreatedDate;

            var mapper = _mapper.Map<City>(city.Data);

            await _unitOfWork.CityRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.CityUpdated);

        }

        public async Task<IResult> DeleteAsync(CityDto cityDto)
        {
            var city = await GetByIdAsync(cityDto.Id);

            var mapper = _mapper.Map<City>(city.Data);
            await _unitOfWork.CityRepository.DeleteAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.CityDeleted);

        }

        public async Task<IDataResult<IEnumerable<CityDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.CityRepository.GetAllAsync(
                selector: x => new CityDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountryId = x.Country.Id,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.Name));

            return new SuccessDataResult<IEnumerable<CityDto>>(result, Messages.CityListed);
        }

        public async Task<IDataResult<IEnumerable<CityDto>>> GetAllByCountryAsync(Guid countryId)
        {
            var result = await _unitOfWork.CityRepository.GetAllAsync(expression: x => x.Deleted != true && x.CountryId == countryId,
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
            if (result == null) throw new BusinessException(Messages.CityNotFound);

            var mapper = _mapper.Map<CityDto>(result);
            return new SuccessDataResult<CityDto>(mapper);
        }

        public async Task<PaginatedResult<CityListDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter)
        {

            var includes = new Expression<Func<City, object>>[]
            {
                x => x.Country      
            };

            var cities = await _unitOfWork.CityRepository.GetListForTableSearch(tableGlobalFilter,includes);
            var mapped = _mapper.Map<PaginatedResult<CityListDto>>(cities);
            return mapped;
        }
    }
}
