using System;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Dtos.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Users
{
    public class UserManager : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> DeleteAsync(UserDto userDto)
        {
            var user = await GetByIdAsync(userDto.Id);
            if (user.Data != null)
            {
                var mapper = _mapper.Map<User>(user.Data);
                await _unitOfWork.UserRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.UserDeleted);
            }

            return user;
        }

        public async Task<IResult> AddAsync(UserDto userDto)
        {
            var mapper = _mapper.Map<User>(userDto);
            await _unitOfWork.UserRepository.AddAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessDataResult<UserDto>(userDto, Messages.UserAdded);

        }

        public async Task<IResult> UpdateAsync(UserDto userDto)
        {
            var user = await GetByIdAsync(userDto.Id);
            if (user.Data != null)
            {
                user.Data.FirstName = userDto.FirstName;
                user.Data.LastName = userDto.LastName;
                user.Data.Email = userDto.Email;
                user.Data.Phone = userDto.Phone;

                var mapper = _mapper.Map<User>(user.Data);
                await _unitOfWork.UserRepository.UpdateAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.UserUpdated);
            }

            return user;
        }

        public async Task<IDataResult<UserDto>> GetByIdAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(br => br.Id == id);
            if (user == null)
            {
                return new ErrorDataResult<UserDto>(Messages.UserNotFound);
            }
            var mapper = _mapper.Map<UserDto>(user);

            return new SuccessDataResult<UserDto>(mapper);
        }

        public async Task<IDataResult<UserDto>> GetByMail(string email)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(u => u.Email == email);
            if (user == null)
            {
                return new ErrorDataResult<UserDto>(Messages.UserNotFound);
            }

            var mapper = _mapper.Map<UserDto>(user);

            return new SuccessDataResult<UserDto>(mapper);


        }

        public async Task<IDataResult<IEnumerable<OperationClaim>>> GetClaims(UserDto userDto)
        {
            var mapper = _mapper.Map<User>(userDto);
            var result = await _unitOfWork.UserRepository.GetClaims(mapper);
            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<OperationClaim>>("Rol Bulunamadı");
            }
            return new SuccessDataResult<IEnumerable<OperationClaim>>(result);
        }

        //[Auth]
        public async Task<IDataResult<IEnumerable<UserDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.UserRepository.GetAllAsync(expression: x => x.Deleted != true,
                selector: x => new UserDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Phone = x.Phone
                },
                orderBy: x => x.OrderBy(x => x.CreatedDate));

            return new SuccessDataResult<IEnumerable<UserDto>>(result, Messages.UserListed);
        }

    }
}
