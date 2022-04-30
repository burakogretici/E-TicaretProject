using System.Threading.Tasks;
using Business.Handlers.UserOperationClaims.Commands;
using Business.Handlers.UserOperationClaims.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaim)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createUserOperationClaim));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperation)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteUserOperation));

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaim)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateUserOperationClaim));
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetUserOperationClaimsQuery()));
        }

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
