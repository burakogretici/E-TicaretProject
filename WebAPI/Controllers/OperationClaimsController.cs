using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.OperationClaims.Commands;
using Business.Handlers.OperationClaims.Queries;
using Entities.Dtos.OperationClaims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaim)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createOperationClaim));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaim)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteOperationClaim));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaim)
        {
        return GetResponseOnlyResult(await Mediator.Send(updateOperationClaim));
        }

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<OperationClaimDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResult(await Mediator.Send(new GetOperationClaimsQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(OperationClaimDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetOperationClaimQuery getOperationClaimQuery)
        {
            return GetResponseOnlyResult(await Mediator.Send(getOperationClaimQuery));
        }

    }
}
