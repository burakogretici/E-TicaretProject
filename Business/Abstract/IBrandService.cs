using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Brands;


namespace Business.Abstract
{
    public interface IBrandService
    {
        Task<IDataResult<BrandDto>> AddAsync(BrandDto brand);
        Task<IResult> UpdateAsync(Brand brand);
        Task<IResult> DeleteAsync(Brand brand);

        Task<IDataResult<List<BrandDto>>> GetAllAsync();
        Task<IDataResult<BrandDto>> GetByIdAsync(Guid id);
    }
}
