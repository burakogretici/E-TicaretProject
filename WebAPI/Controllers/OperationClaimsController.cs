using System.Threading.Tasks;
using Business.Handlers.OperationClaims.Commands;
using Business.Handlers.OperationClaims.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaim)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createOperationClaim));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaim)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteOperationClaim));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaim)
        {
        return GetResponseOnlyResultMessage(await Mediator.Send(updateOperationClaim));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetOperationClaimsQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetOperationClaimQuery getOperationClaimQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getOperationClaimQuery));
        }

    }
}
