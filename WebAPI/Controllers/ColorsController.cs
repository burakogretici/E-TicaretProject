using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Colors.Commands;
using Business.Handlers.Colors.Queries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : BaseController
    {

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetColorsQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetColorQuery getColorQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getColorQuery));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateColorCommand createColor)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createColor));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateColorCommand updateColor)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateColor));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteColorCommand deleteColor)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteColor));
        }

    }
}

