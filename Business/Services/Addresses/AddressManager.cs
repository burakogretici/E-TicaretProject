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
using Entities.Dtos.Addresses;
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Addresses
{
    public class AddressManager : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AddressRules _addressRules;
        public AddressManager(IMapper mapper, IUnitOfWork unitOfWork, AddressRules addressRules) 
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _addressRules = addressRules;
        }

        public async Task<IDataResult<AddressDto>> AddAsync(AddressDto addressDto)
        {

            IResult result = BusinessRules.Run();
            if (result == null)
            {
                var mapper = _mapper.Map<Address>(addressDto);
                await _unitOfWork.AddressRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessDataResult<AddressDto>(addressDto, Messages.AddressAdded);
            }

            return new ErrorDataResult<AddressDto>(result.Message);
        }

        public async Task<IResult> UpdateAsync(AddressDto addressDto)
        {
            var address = await GetByIdAsync(addressDto.Id);
            if (address.Data != null)
            {
                IResult result = BusinessRules.Run();
                if (result == null)
                {
                    address.Data.CustomerId = addressDto.CustomerId;
                    address.Data.CityId = addressDto.CustomerId;
                    address.Data.CountryId = addressDto.CustomerId;
                    address.Data.AddressDetail = addressDto.AddressDetail;
                    address.Data.PostalCode = addressDto.PostalCode;

                    var mapper = _mapper.Map<Address>(address.Data);
                    await _unitOfWork.AddressRepository.UpdateAsync(mapper);
                    await _unitOfWork.Commit();
                    return new SuccessResult(Messages.AddressUpdated);
                }

                return result;
            }
            return address;
        }

        public async Task<IResult> DeleteAsync(AddressDto addressDto)
        {
            var address = await GetByIdAsync(addressDto.Id);
            if (address.Data != null)
            {
                var mapper = _mapper.Map<Address>(address.Data);
                await _unitOfWork.AddressRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.AddressDeleted);
            }

            return address;
        }

        public async Task<IDataResult<IEnumerable<AddressListDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.AddressRepository.GetAllAsync(expression: x => x.Deleted != true,
                include: x => x
                    .Include(a=>a.Customer).ThenInclude(c=>c.User)
                    .Include(a=>a.Country)
                    .Include(a=>a.City),
                selector: x => new AddressListDto
                {
                    Id = x.Id,
                    CustomerName = x.Customer.User.FirstName,
                    CustomerLastName = x.Customer.User.LastName,
                    Country = x.Country.Name,
                    City = x.City.Name,
                    AddressDetail = x.AddressDetail,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x=>x.CreatedDate));

            return new SuccessDataResult<IEnumerable<AddressListDto>>(result, Messages.AddressListed);
        }

        public async Task<IDataResult<IEnumerable<AddressListDto>>> GetAllByCountryIdAsync(Guid countryId)
        {
            var result = await _unitOfWork.AddressRepository.GetAllAsync(expression: x => x.Deleted != true && x.CountryId == countryId,
                include: x => x
                    .Include(a => a.Customer).ThenInclude(c => c.User)
                    .Include(a => a.Country)
                    .Include(a => a.City),
                selector: x => new AddressListDto
                {
                    Id = x.Id,
                    CustomerName = x.Customer.User.FirstName,
                    CustomerLastName = x.Customer.User.LastName,
                    Country = x.Country.Name,
                    City = x.City.Name,
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
                    .Include(a => a.Customer).ThenInclude(c => c.User)
                    .Include(a => a.Country)
                    .Include(a => a.City),
                selector: x => new AddressListDto
                {
                    Id = x.Id,
                    CustomerName = x.Customer.User.FirstName,
                    CustomerLastName = x.Customer.User.LastName,
                    Country = x.Country.Name,
                    City = x.City.Name,
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
            var result = await _unitOfWork.AddressRepository.GetAllAsync(expression: x => x.Deleted != true && x.CustomerId == customerId,
                include: x => x
                    .Include(a => a.Customer).ThenInclude(c => c.User)
                    .Include(a => a.Country)
                    .Include(a => a.City),
                selector: x => new AddressListDto
                {
                    Id = x.Id,
                    CustomerName = x.Customer.User.FirstName,
                    CustomerLastName = x.Customer.User.LastName,
                    Country = x.Country.Name,
                    City = x.City.Name,
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
            if (result == null)
            {
                return new ErrorDataResult<AddressDto>(Messages.AddressNotFound);
            }
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
