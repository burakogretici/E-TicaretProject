using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.UserOperationClaims.Commands;
using Business.Handlers.UserOperationClaims.Queries;
using Entities.Dtos.UserOperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaim)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createUserOperationClaim));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserOperationClaimCommand deleteUserOperation)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteUserOperation));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaim)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateUserOperationClaim));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserOperationClaimDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetUserOperationClaimsQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserOperationClaimDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetUserOperationClaimQuery getUserOperationClaimQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getUserOperationClaimQuery));
        }

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
