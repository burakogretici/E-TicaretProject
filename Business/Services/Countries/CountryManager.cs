using Business.Constants;
using Business.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Countries
{
    public class CountryManager : ServiceBase, ICountryService
    {
        private readonly CountryRules _countryRules;
        public CountryManager(IServiceProvider serviceProvider, CountryRules countryRules) : base(serviceProvider)
        {
            _countryRules = countryRules;
        }

        public async Task<IDataResult<CountryDto>> AddAsync(CountryDto countryDto)
        {
            await _countryRules.CountryNameAlreadyExists(countryDto.Name);

            var mapper = _mapper.Map<Country>(countryDto);
            await _unitOfWork.CountryRepository.AddAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessDataResult<CountryDto>(countryDto, Messages.CountryAdded);

        }

        public async Task<IResult> UpdateAsync(CountryDto countryDto)
        {

            var country = await GetByIdAsync(countryDto.Id);

            await _countryRules.CountryNameAlreadyExists(countryDto.Name);
            countryDto.CreatedDate = country.Data.CreatedDate;

            var mapper = _mapper.Map<Country>(country.Data);
            await _unitOfWork.CountryRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.CountryUpdated);

        }

        public async Task<IResult> DeleteAsync(CountryDto countryDto)
        {
            var country = await GetByIdAsync(countryDto.Id);

            var mapper = _mapper.Map<Country>(country.Data);
            await _unitOfWork.CountryRepository.DeleteAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.CountryDeleted);
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
            if (result == null) throw new BusinessException(Messages.CountryNotFound);

            var mapper = _mapper.Map<CountryDto>(result);
            return new SuccessDataResult<CountryDto>(mapper);
        }

        public async Task<PaginatedResult<CountryDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter)
        {
            var countries = await _unitOfWork.CountryRepository.GetListForTableSearch(tableGlobalFilter);
            var mapped = _mapper.Map<PaginatedResult<CountryDto>>(countries);
            return mapped;
        }
    }
}
