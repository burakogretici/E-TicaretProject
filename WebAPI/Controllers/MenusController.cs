using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.Menus.Commands;
using Business.Handlers.Menus.Queries;
using Entities.Dtos.Menus;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateMenuCommand createMenu)
        {
            return GetResponseOnlyResult(await Mediator.Send(createMenu));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteMenuCommand deleteMenu)
        {
            return GetResponseOnlyResult(await Mediator.Send(deleteMenu));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateMenuCommand updateMenu)
        {
            return GetResponseOnlyResult(await Mediator.Send(updateMenu));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MenuDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResult(await Mediator.Send(new GetMenusQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MenuDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetMenuQuery getMenuQuery)
        {
            return GetResponseOnlyResult(await Mediator.Send(getMenuQuery));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MenuDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetAllByParentMenu/{Id}")]
        public async Task<IActionResult> GetAllByParentMenu([FromRoute] GetParentMenusQuery getParentMenusQuery)
        {
            return GetResponseOnlyResult(await Mediator.Send(getParentMenusQuery));
        }
    }
}