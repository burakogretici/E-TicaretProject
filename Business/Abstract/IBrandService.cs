using System.Collections.Generic;
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

        IDataResult<List<BrandDto>> GetAll();
        IDataResult<BrandDto> GetById(long id);
    }
}
