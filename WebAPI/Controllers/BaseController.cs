using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResponse<T>(IDataResult<T> result)
        {
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResponseOnlyResult(IResult result)
        {
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResponseOnlyResultMessage(IResult result)
        {
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResponseOnlyResultData<T>(IDataResult<T> result)
        {
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
    }
}
