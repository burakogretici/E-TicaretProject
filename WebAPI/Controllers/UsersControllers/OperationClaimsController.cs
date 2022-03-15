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
    public class OperationClaimsController : ControllerBase
    {
        IOperationClaimService _operationClaimService;
        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] OperationClaim operationClaim)
        {
            var result = await _operationClaimService.AddAsync(operationClaim);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] OperationClaim operationClaim)
        {
            var result = await _operationClaimService.DeleteAsync(operationClaim);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] OperationClaim operationClaim)
        {
            var result = await _operationClaimService.UpdateAsync(operationClaim);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _operationClaimService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        //[HttpGet("getbyoperationclaim")]
        //public IActionResult GetByOperationClaim(int operationClaimId)
        //{
        //    var result = _operationClaimService.GetByOperationClaim(operationClaimId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

    }
}
