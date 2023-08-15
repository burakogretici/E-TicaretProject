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
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaim)
        {
            return GetResponseOnlyResult(await Mediator.Send(createUserOperationClaim));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserOperationClaimCommand deleteUserOperation)
        {
            return GetResponseOnlyResult(await Mediator.Send(deleteUserOperation));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaim)
        {
            return GetResponseOnlyResult(await Mediator.Send(updateUserOperationClaim));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserOperationClaimDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResult(await Mediator.Send(new GetUserOperationClaimsQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserOperationClaimDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdUserOperationClaim([FromRoute] GetByIdUserOperationClaimQuery getByIdUserOperationClaimQuery)
        {
            return GetResponseOnlyResult(await Mediator.Send(getByIdUserOperationClaimQuery));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserOperationClaimDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetUserOperationClaimQuery getUserOperationClaimQuery)
        {
            return GetResponseOnlyResult(await Mediator.Send(getUserOperationClaimQuery));
        }
    
    }
}
