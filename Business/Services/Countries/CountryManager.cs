using AutoMapper;
using Business.Constants;
using Business.Rules;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Dtos.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Countries
{
    public class CountryManager : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CountryRules _countryRules;
        public CountryManager(IMapper mapper, IUnitOfWork unitOfWork, CountryRules countryRules)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _countryRules = countryRules;
        }

        public async Task<IDataResult<CountryDto>> AddAsync(CountryDto countryDto)
        {
            IResult result = BusinessRules.Run(await _countryRules.CountryNameAlreadyExists(countryDto.Name));
            if (result == null)
            {
                var mapper = _mapper.Map<Country>(countryDto);
                await _unitOfWork.CountryRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessDataResult<CountryDto>(countryDto, Messages.CountryAdded);
            }
            return new ErrorDataResult<CountryDto>(result.Message);
        }

        public async Task<IResult> UpdateAsync(CountryDto countryDto)
        {
            var country = await GetByIdAsync(countryDto.Id);
            if (country.Data != null)
            {
                IResult result = BusinessRules.Run(await _countryRules.CountryNameAlreadyExists(countryDto.Name));
                if (result == null)
                {
                    country.Data.Name = countryDto.Name;
                    var mapper = _mapper.Map<Country>(country.Data);
                    await _unitOfWork.CountryRepository.UpdateAsync(mapper);
                    await _unitOfWork.Commit();
                    return new SuccessResult(Messages.CountryUpdated);
                }

                return result;
            }
            return country;
        }

        public async Task<IResult> DeleteAsync(CountryDto countryDto)
        {
            var country = await GetByIdAsync(countryDto.Id);
            if (country.Data != null)
            {
                var mapper = _mapper.Map<Country>(country.Data);
                await _unitOfWork.CountryRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CountryDeleted);
            }

            return country;

        }

        public async Task<IDataResult<IEnumerable<CountryDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.CountryRepository.GetAllAsync(expression: x => x.Deleted != true,
                selector: x => new CountryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.Name));

            return new SuccessDataResult<IEnumerable<CountryDto>>(result, Messages.CountryListed);
        }

        public async Task<IDataResult<CountryDto>> GetByIdAsync(Guid countryId)
        {
            var result = await _unitOfWork.CountryRepository.GetAsync(br => br.Id == countryId);
            if (result == null)
            {
                return new ErrorDataResult<CountryDto>(Messages.CountryNotFound);
            }
            var mapper = _mapper.Map<CountryDto>(result);
            return new SuccessDataResult<CountryDto>(mapper);
        }
    }
}
