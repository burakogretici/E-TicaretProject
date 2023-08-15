using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.UserOperationClaim;
using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.EntityFrameworkCore;
using Business.BusinessAspects;
using Entities.Dtos.OperationClaims;
using Business.Services.Users;
using Business.Rules;

namespace Business.Services.UserOperationClaims
{
    public class UserOperationClaimManager : ServiceBase, IUserOperationClaimService
    {
        private readonly IUserService _userService;
        private readonly UserOperationClaimRules _userOperationClaimRules;
        public UserOperationClaimManager(IServiceProvider serviceProvider, IUserService userService, UserOperationClaimRules userOperationClaimRules) : base(serviceProvider)
        {
            _userService = userService;
            _userOperationClaimRules = userOperationClaimRules;
        }

        //[SecuredOperation("UserOperationClaim.Add,Admin")]
        //public async Task<IResult> AddAsync(UserOperationClaimDto userOperationClaimOperationClaimDto)
        //{
        //    try
        //    {
        //        var mapper = _mapper.Map<UserOperationClaim>(userOperationClaimOperationClaimDto);
        //        await _unitOfWork.UserOperationClaimRepository.AddAsync(mapper);
        //        await _unitOfWork.Commit();
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return new SuccessDataResult<UserOperationClaimDto>(userOperationClaimOperationClaimDto, Messages.UserOperationClaimAdded);

        //}
        public async Task<IResult> AddAsync(UserOperationClaimDto userOperationClaimDto)
        {

            foreach (var operationClaimId in userOperationClaimDto.OperationClaimIds)
            {
               await _userOperationClaimRules.UserRoleAlreadyExists(operationClaimId);
                var userOperationClaim = new UserOperationClaim
                {
                    UserId = userOperationClaimDto.UserId,
                    OperationClaimId = operationClaimId
                };

                await _unitOfWork.UserOperationClaimRepository.AddAsync(userOperationClaim);
            }

            await _unitOfWork.Commit();


            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        [SecuredOperation("UserOperationClaim.Update,Admin")]
        public async Task<IResult> UpdateAsync(UserOperationClaimDto userOperationClaimOperationClaimDto)
        {
            var userOperationClaimOperationClaim = await GetByIdAsync(userOperationClaimOperationClaimDto.Id);
            userOperationClaimOperationClaimDto.CreatedDate = userOperationClaimOperationClaim.Data.CreatedDate;

            var mapper = _mapper.Map<UserOperationClaim>(userOperationClaimOperationClaim.Data);
            await _unitOfWork.UserOperationClaimRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessResult(Messages.UserOperationClaimUpdated);

        }

        [SecuredOperation("UserOperationClaim.Delete,Admin")]
        public async Task<IResult> DeleteAsync(DeleteUserOperationCLaimDto deleteUserOperation)
        {
            var user = await _userService.GetByIdAsync(deleteUserOperation.UserId);

            //var userOperationClaimResult = await GetByIdAsync(deleteUserOperation.UserId);
            if (!user.Success)
            {
                // Kullanıcı bulunamadı, hata döndür
                return new ErrorResult(user.Message);
            }

            var userOperationClaim = user.Data;

            // Gelen roleIds değerlerini kontrol et
            if (deleteUserOperation.RoleIds == null || deleteUserOperation.RoleIds.Count == 0)
            {
                // RoleIds boş veya geçersiz, hata döndür
                return new ErrorResult("RoleIds cannot be empty.");
            }

          
            foreach (var roleId in deleteUserOperation.RoleIds)
            {
                // RoleIds listesindeki roleId, kullanıcının sahip olduğu bir rol mü?
                //if (!userOperationClaim.OperationClaimIds.Contains(roleId))
                //{
                //    // Kullanıcı bu role sahip değil, hata döndür
                //    return new ErrorResult("User does not have the specified role.");
                //}

                // Kullanıcının belirli rolünü silmek için gerekli işlemleri yapın
                // Örnek olarak:
                var userRoleToDelete = userOperationClaim.UserOperationClaims.FirstOrDefault(ur => ur.OperationClaimId == roleId);
                if (userRoleToDelete != null)
                {
                    await _unitOfWork.UserOperationClaimRepository.DeleteAsync(userRoleToDelete);
                }
            }
            // RoleIds listesindeki her bir role için kontrol yap ve silme işlemi gerçekleştir
            //foreach (var roleId in roleIds)
            //{
            //    // RoleIds listesindeki roleId, kullanıcının sahip olduğu bir rol mü?
            //    if (!userOperationClaim.OperationClaimIds.Contains(roleId))
            //    {
            //        // Kullanıcı bu role sahip değil, hata döndür
            //        return new ErrorResult("User does not have the specified role.");
            //    }

            //    // Silme işlemini gerçekleştir
            //    await _unitOfWork.UserOperationClaimRepository.DeleteAsync(userId, roleId);
            //}

            // Veritabanı değişikliklerini kaydet
            await _unitOfWork.Commit();

            return new SuccessResult(Messages.UserOperationClaimDeleted);
        }
        public async Task<IDataResult<IEnumerable<UserOperationClaimDto>>> GetAllAsync()
        {
            var userOperationClaims = await _unitOfWork.UserOperationClaimRepository
                .GetAllAsync(x => new UserOperationClaimDto
                {
                    UserId = x.UserId,
                    OperationClaimIds = new List<Guid> { x.OperationClaimId },
                    UserName = x.User.FullName,
                    OperationClaimNames = new List<string> { x.OperationClaim.Name },
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted
                },
                x => x.Deleted != true,
                x => x.OrderBy(x => x.CreatedDate),
                x => x.Include(p => p.User).Include(p => p.OperationClaim));

            var groupedUserOperationClaims = userOperationClaims
                .GroupBy(x => x.UserId)
                .Select(group =>
                {
                    var userOperationClaim = group.First();
                    return new UserOperationClaimDto
                    {
                        UserId = userOperationClaim.UserId,
                        UserName = userOperationClaim.UserName,
                        OperationClaimIds = group.SelectMany(x => x.OperationClaimIds).ToList(),
                        OperationClaimNames = group.SelectMany(x => x.OperationClaimNames).ToList(),
                        CreatedDate = userOperationClaim.CreatedDate,
                        UpdatedDate = userOperationClaim.UpdatedDate,
                        Deleted = userOperationClaim.Deleted
                    };
                })
                .OrderBy(x => x.CreatedDate)
                .ToList();

            return new SuccessDataResult<IEnumerable<UserOperationClaimDto>>(groupedUserOperationClaims, Messages.UserOperationClaimListed);
        }
 


        public async Task<IDataResult<IEnumerable<UserOperationClaimDto>>> GetAllByOperationClaim(Guid operationClaimId)
        {
            var userOperationClaims = await _unitOfWork.UserOperationClaimRepository
                .GetAllAsync(x => new UserOperationClaimDto
                {
                    UserId = x.UserId,
                    OperationClaimIds = new List<Guid> { x.OperationClaimId },
                    UserName = x.User.FullName,
                    OperationClaimNames = new List<string> { x.OperationClaim.Name },
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted
                },
                    x => x.OperationClaimId == operationClaimId,
                    orderBy: x => x.OrderBy(x => x.CreatedDate),
                    include: x => x.Include(p => p.User).Include(p => p.OperationClaim));

            var groupedUserOperationClaims = userOperationClaims
                .GroupBy(x => x.UserId)
                .Select(group =>
                {
                    var userOperationClaim = group.First();
                    return new UserOperationClaimDto
                    {
                        UserId = userOperationClaim.UserId,
                        UserName = userOperationClaim.UserName,
                        OperationClaimIds = group.SelectMany(x => x.OperationClaimIds).ToList(),
                        OperationClaimNames = group.SelectMany(x => x.OperationClaimNames).ToList(),
                        CreatedDate = userOperationClaim.CreatedDate,
                        UpdatedDate = userOperationClaim.UpdatedDate,
                        Deleted = userOperationClaim.Deleted
                    };
                })
                .OrderBy(x => x.CreatedDate)
                .ToList();

            return new SuccessDataResult<IEnumerable<UserOperationClaimDto>>(groupedUserOperationClaims, Messages.UserOperationClaimListed);
        }



        public async Task<IDataResult<UserOperationClaimListDto>> GetAllByUser(Guid userId)
        {
            var userOperationClaims = await _unitOfWork.UserOperationClaimRepository
      .GetAllAsync(
          x => new UserOperationClaimListDto
          {
              UserId = x.UserId,
              UserName = x.User.FullName,
              OperationClaims = new List<OperationClaimDto> { new OperationClaimDto { Id = x.OperationClaimId, Name = x.OperationClaim.Name } },
              CreatedDate = x.CreatedDate,
              UpdatedDate = x.UpdatedDate,
              Deleted = x.Deleted
          },
              x => x.UserId == userId && x.Deleted != true,
              orderBy: x => x.OrderBy(x => x.CreatedDate),
          include: x => x.Include(p => p.User).Include(p => p.OperationClaim));



            var groupedUserOperationClaim = userOperationClaims
                .GroupBy(x => x.UserId)
                .Select(group =>
                {
                    var userOperationClaim = group.First();
                    var operationClaims = group.Select(x => new OperationClaimDto
                    {
                        Id = x.OperationClaims.First().Id,
                        Name = x.OperationClaims.First().Name,
                    }).ToList();
                    return new UserOperationClaimListDto
                    {

                        UserId = userOperationClaim.UserId,
                        UserName = userOperationClaim.UserName,
                        OperationClaims = operationClaims,
                        CreatedDate = userOperationClaim.CreatedDate,
                        UpdatedDate = userOperationClaim.UpdatedDate,
                        Deleted = userOperationClaim.Deleted
                    };
                })
                .OrderBy(x => x.CreatedDate)
                .FirstOrDefault();

            return new SuccessDataResult<UserOperationClaimListDto>(groupedUserOperationClaim, Messages.UserOperationClaimListed);

        }


   


        [SecuredOperation("UserOperationClaim.Get,Admin")]
        public async Task<IDataResult<UserOperationClaimDto>> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.UserOperationClaimRepository.GetAsync(br => br.Id == id);
            if (result == null) throw new BusinessException(Messages.UserOperationClaimNotFound);

            var mapper = _mapper.Map<UserOperationClaimDto>(result);
            return new SuccessDataResult<UserOperationClaimDto>(mapper);
        }

    }
}

