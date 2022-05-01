using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.Users.Commands;
using Business.Handlers.Users.Queries;
using Entities.Dtos.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserCommand createUser)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createUser));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand deleteUser)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteUser));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUser)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateUser));
        }

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<UserDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetUsersQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetUserQuery getUserQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getUserQuery));
        }
    }
}
