using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Shippers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Shippers
{
    public class ShipperManager : ServiceBase, IShipperService
    {
        public ShipperManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            
        }

        public async Task<IDataResult<ShipperDto>> AddAsync(ShipperDto shipperDto)
        {

            var mapper = _mapper.Map<Shipper>(shipperDto);
            await _unitOfWork.ShipperRepository.AddAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessDataResult<ShipperDto>(shipperDto, Messages.ShipperAdded);
        }

        public async Task<IResult> UpdateAsync(ShipperDto shipperDto)
        {

            var city = await GetByIdAsync(shipperDto.Id);
            shipperDto.CreatedDate = city.Data.CreatedDate;

            var mapper = _mapper.Map<Shipper>(city.Data);

            await _unitOfWork.ShipperRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.ShipperUpdated);

        }

        public async Task<IResult> DeleteAsync(ShipperDto shipperDto)
        {
            var city = await GetByIdAsync(shipperDto.Id);

            var mapper = _mapper.Map<Shipper>(city.Data);
            await _unitOfWork.ShipperRepository.DeleteAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.ShipperDeleted);

        }

        public async Task<IDataResult<IEnumerable<ShipperDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.ShipperRepository.GetAllAsync(expression: x => x.Deleted != true,
                selector: x => new ShipperDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.Name));

            return new SuccessDataResult<IEnumerable<ShipperDto>>(result, Messages.ShipperListed);
        }

    

        public async Task<IDataResult<ShipperDto>> GetByIdAsync(Guid cityId)
        {
            var result = await _unitOfWork.ShipperRepository.GetAsync(br => br.Id == cityId);
            if (result == null) throw new BusinessException(Messages.ShipperNotFound);

            var mapper = _mapper.Map<ShipperDto>(result);
            return new SuccessDataResult<ShipperDto>(mapper);
        }
    }
}
