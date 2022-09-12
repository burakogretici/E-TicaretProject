using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Brands
{
    public interface IBrandService
    {
        Task<IDataResult<BrandDto>> AddAsync(BrandDto brand);
        Task<IResult> UpdateAsync(BrandDto brand);
        Task<IResult> DeleteAsync(BrandDto brand);

        Task<IDataResult<IEnumerable<BrandDto>>> GetAllAsync();
        Task<IDataResult<BrandDto>> GetByIdAsync(Guid id);
    }
}
