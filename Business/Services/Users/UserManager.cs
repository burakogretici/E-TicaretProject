using System;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Users;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Security.Hashing;
using Business.BusinessAspects;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Business.Services.Authorizations;

namespace Business.Services.Users
{
    public class UserManager : ServiceBase, IUserService
    {
        public UserManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [SecuredOperation("Admin,User.Delete")]
        public async Task<IResult> DeleteAsync(UserDto userDto)
        {
            var user = await GetByIdAsync(userDto.Id);

            var mapper = _mapper.Map<User>(user.Data);
            await _unitOfWork.UserRepository.DeleteAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessResult(Messages.UserDeleted);

        }

        //[SecuredOperation("Admin,User.Add")]
        public async Task<IResult> AddAsync(UserDto userDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);

            userDto.FullName = userDto.FirstName + " " + userDto.LastName;
            userDto.PasswordHash = passwordHash;
            userDto.PasswordSalt = passwordSalt;

            var mapper = _mapper.Map<User>(userDto);

            await _unitOfWork.UserRepository.AddAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessDataResult<UserDto>(userDto, Messages.UserAdded);


        }

        [SecuredOperation("Admin,User.Update")]
        public async Task<IResult> UpdateAsync(UserDto userDto)
        {

            var user = await GetByIdAsync(userDto.Id);
            userDto.CreatedDate = user.Data.CreatedDate;
            byte[] passwordHash, passwordSalt;

            if (userDto.PasswordHash != null && userDto.PasswordSalt != null)
            {
                userDto.PasswordHash = user.Data.PasswordHash;
                userDto.PasswordSalt = user.Data.PasswordSalt;
            }
            else
            {
                HashingHelper.CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);
                user.Data.PasswordHash = passwordHash;
                user.Data.PasswordSalt = passwordSalt;
            }
            var mapper = _mapper.Map<User>(userDto);
            await _unitOfWork.UserRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.UserUpdated);
        }
        [SecuredOperation("Admin,User.Get")]
        public async Task<IDataResult<UserDto>> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.UserRepository.GetAsync(br => br.Id == id, include: u => u.Include(x => x.UserOperationClaims));
            if (result == null) throw new BusinessException(Messages.UserNotFound);

            var mapper = _mapper.Map<UserDto>(result);
            return new SuccessDataResult<UserDto>(mapper);
        }

        public async Task<IDataResult<UserDto>> GetByMail(string email)
        {
            var result = await _unitOfWork.UserRepository.GetAsync(u => u.Email == email);
            if (result == null) return new ErrorDataResult<UserDto>(Messages.UserNotFound);

            var mapper = _mapper.Map<UserDto>(result);
            return new SuccessDataResult<UserDto>(mapper);
        }

        public async Task<IDataResult<IEnumerable<OperationClaim>>> GetClaims(UserDto userDto)
        {
            var mapper = _mapper.Map<User>(userDto);
            var result = await _unitOfWork.UserRepository.GetClaims(mapper);

            //todo buraya bir bak
            if (result == null) throw new BusinessException("Rol Bulunamadı");

            return new SuccessDataResult<IEnumerable<OperationClaim>>(result);
        }
        //[SecuredOperation("Admin,User.List")]
        //public async Task<IDataResult<IEnumerable<UserDto>>> GetAllAsync()
        //{
        //    var result = await _unitOfWork.UserRepository.GetAllAsync(expression: x => x.Deleted != true,
        //        selector: x => new UserDto
        //        {
        //            Id = x.Id,
        //            FirstName = x.FirstName,
        //            LastName = x.LastName,
        //            FullName = x.FullName,
        //            Email = x.Email,
        //            Phone = x.Phone
        //        },
        //        orderBy: x => x.OrderBy(x => x.CreatedDate)); ;

        //    return new SuccessDataResult<IEnumerable<UserDto>>(result, Messages.UserListed);
        //}

        public async Task<PaginatedResult<UserDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter)
        {
            var users = await _unitOfWork.UserRepository.GetListForTableSearch(tableGlobalFilter);
            var mapped = _mapper.Map<PaginatedResult<UserDto>>(users);
            return mapped;
        }
    }
}
