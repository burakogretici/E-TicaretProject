using Business.Abstract.UserService;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace WebAPI.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        IUserOperationClaimService _userOperationClaimService;
        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UserOperationClaim userOperationClaim)
        {
            var result = await _userOperationClaimService.AddAsync(userOperationClaim);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] UserOperationClaim userOperationClaim)
        {
            var result = await _userOperationClaimService.DeleteAsync(userOperationClaim);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UserOperationClaim userOperationClaim)
        {
            var result = await _userOperationClaimService.UpdateAsync(userOperationClaim);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userOperationClaimService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        //[HttpGet("getbyuseroperationclaim")]
        //public IActionResult GetByUserOperationClaim(int userOperationClaimId)
        //{
        //    var result = _userOperationClaimService.GetByUserOperationClaim(userOperationClaimId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpGet("getbyoperationclaim")]
        //public IActionResult GetByOperationClaim(int operationClaimId)
        //{
        //    var result = _userOperationClaimService.GetByUserOperationClaim(operationClaimId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}
