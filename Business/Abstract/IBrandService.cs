using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<BrandDto> Add(BrandDto brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);

        Task<IDataResult<List<BrandDto>>> GetAllAsync();
        Task<IDataResult<BrandDto>> GetByIdAsync(long id);
    }
}
