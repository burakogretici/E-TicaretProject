using System;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Dtos.Users;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;

namespace Business.Services.Users
{
    public interface IUserService
    {
        Task<IResult> AddAsync(UserDto userDto);
        Task<IResult> UpdateAsync(UserDto userDto);
        Task<IResult> DeleteAsync(UserDto userDto);

        //Task<IDataResult<IEnumerable<UserDto>>> GetAllAsync();

        Task<PaginatedResult<UserDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter);

        Task<IDataResult<UserDto>> GetByIdAsync(Guid id);

        Task<IDataResult<UserDto>> GetByMail(string email);
        Task<IDataResult<IEnumerable<OperationClaim>>> GetClaims(UserDto userDto);

    }
}
