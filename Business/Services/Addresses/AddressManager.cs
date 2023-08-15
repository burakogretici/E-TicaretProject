using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.BusinessAspects;
using Business.Constants;
using Business.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Addresses;
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Addresses
{
    public class AddressManager : ServiceBase, IAddressService
    {
        private readonly AddressRules _addressRules;
        public AddressManager(IServiceProvider serviceProvider, AddressRules addressRules) : base(serviceProvider)
        {
            _addressRules = addressRules;
        }

        public async Task<IDataResult<AddressDto>> AddAsync(AddressDto addressDto)
        {
            var mapper = _mapper.Map<Address>(addressDto);
            await _unitOfWork.AddressRepository.AddAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessDataResult<AddressDto>(addressDto, Messages.AddressAdded);
        }

        public async Task<IResult> UpdateAsync(AddressDto addressDto)
        {
            var address = await GetByIdAsync(addressDto.Id);
            addressDto.CreatedDate = address.Data.CreatedDate;

            var mapper = _mapper.Map<Address>(address.Data);
            await _unitOfWork.AddressRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.AddressUpdated);

        }

        public async Task<IResult> DeleteAsync(AddressDto addressDto)
        {
            var address = await GetByIdAsync(addressDto.Id);

            var mapper = _mapper.Map<Address>(address.Data);
            await _unitOfWork.AddressRepository.DeleteAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessResult(Messages.AddressDeleted);

        }

        public async Task<IDataResult<IEnumerable<AddressListDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.AddressRepository.GetAllAsync(expression: x => x.Deleted != true,
                include: x => x
                    .Include(a => a.User)
                    .Include(a => a.Country)
                    .Include(a => a.City),
                selector: x => new AddressListDto
                {
                    Id = x.Id,
                    FullName = x.User.FullName,
                    CountryName = x.Country.Name,
                    CityName = x.City.Name,
                    AddressDetail = x.AddressDetail,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.CreatedDate));

            return new SuccessDataResult<IEnumerable<AddressListDto>>(result, Messages.AddressListed);
        }

        [SecuredOperation("Address.List,Admin")]
        public async Task<PaginatedResult<AddressListDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter)
        {
            var includes = new Expression<Func<Address, object>>[]
            {
                x => x.User,
                x => x.City,
                x=>x.Country
            };

            var address = await _unitOfWork.AddressRepository.GetListForTableSearch(tableGlobalFilter, includes);

            var mapped = _mapper.Map<PaginatedResult<AddressListDto>>(address);
            return mapped;

        }
        public async Task<IDataResult<IEnumerable<AddressListDto>>> GetAllByCountryIdAsync(Guid countryId)
        {
            var result = await _unitOfWork.AddressRepository.GetAllAsync(expression: x => x.Deleted != true && x.CountryId == countryId,
                    include: x => x
                        .Include(a => a.User)
                        .Include(a => a.Country)
                        .Include(a => a.City),
                    selector: x => new AddressListDto
                    {
                        Id = x.Id,
                        FullName = x.User.FullName,
                        CountryName = x.Country.Name,
                        CityName = x.City.Name,
                        AddressDetail = x.AddressDetail,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate,
                        Deleted = x.Deleted,
                    },
                    orderBy: x => x.OrderBy(x => x.CreatedDate));

            return new SuccessDataResult<IEnumerable<AddressListDto>>(result, Messages.AddressListed);
        }

        public async Task<IDataResult<IEnumerable<AddressListDto>>> GetAllByCityIdAsync(Guid cityId)
        {
            var result = await _unitOfWork.AddressRepository.GetAllAsync(expression: x => x.Deleted != true && x.CityId == cityId,
                include: x => x
                    .Include(a => a.User)
                    .Include(a => a.Country)
                    .Include(a => a.City),
                selector: x => new AddressListDto
                {
                    Id = x.Id,
                    FullName = x.User.FullName,
                    CountryName = x.Country.Name,
                    CityName = x.City.Name,
                    AddressDetail = x.AddressDetail,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.CreatedDate));

            return new SuccessDataResult<IEnumerable<AddressListDto>>(result, Messages.AddressListed);
        }

        public async Task<IDataResult<IEnumerable<AddressListDto>>> GetAllByUserIdAsync(Guid customerId)
        {
            var result = await _unitOfWork.AddressRepository.GetAllAsync(expression: x => x.Deleted != true && x.UserId == customerId,
                include: x => x
                    .Include(a => a.User)
                    .Include(a => a.Country)
                    .Include(a => a.City),
                selector: x => new AddressListDto
                {
                    Id = x.Id,
                    FullName = x.User.FullName,
                    CountryName = x.Country.Name,
                    CityName = x.City.Name,
                    AddressDetail = x.AddressDetail,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.CreatedDate));

            return new SuccessDataResult<IEnumerable<AddressListDto>>(result, Messages.AddressListed);
        }
        public async Task<IDataResult<AddressDto>> GetByIdAsync(Guid addressId)
        {
            var result = await _unitOfWork.AddressRepository.GetAsync(br => br.Id == addressId);
            if (result == null) throw new BusinessException(Messages.AddressNotFound);

            var mapper = _mapper.Map<AddressDto>(result);
            return new SuccessDataResult<AddressDto>(mapper);
        }

        public async Task<IDataResult<List<AddressDetailDto>>> GetAddressDetail()
        {
            var result = await _unitOfWork.AddressRepository.GetAddressDetails();
            return new SuccessDataResult<List<AddressDetailDto>>(result);
        }
    }
}
