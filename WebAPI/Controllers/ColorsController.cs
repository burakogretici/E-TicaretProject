using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Colors.Commands;
using Business.Handlers.Colors.Queries;
using Entities.Dtos.Colors;
using Microsoft.AspNetCore.Http;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<ColorDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetTableSearch([FromQuery] TableGlobalFilter tableGlobalFilter)
        {
            GetColorsTableQuery getColorsQuery = new() { TableGlobalFilter = tableGlobalFilter };
            return GetResponseOnlyResult(await Mediator.Send(getColorsQuery));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ColorDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetColorQuery getColorQuery)
        {
            return GetResponseOnlyResult(await Mediator.Send(getColorQuery));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateColorCommand createColor)
        {
            return GetResponseOnlyResult(await Mediator.Send(createColor));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateColorCommand updateColor)
        {
            return GetResponseOnlyResult(await Mediator.Send(updateColor));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteColorCommand deleteColor)
        {
            return GetResponseOnlyResult(await Mediator.Send(deleteColor));
        }
    }
}

