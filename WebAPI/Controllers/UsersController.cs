using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.Users.Commands;
using Business.Handlers.Users.Queries;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;
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
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateUserCommand createUser)
        {
            return GetResponseOnlyResult(await Mediator.Send(createUser));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand deleteUser)
        {
            return GetResponseOnlyResult(await Mediator.Send(deleteUser));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUser)
        {
            return GetResponseOnlyResult(await Mediator.Send(updateUser));
        }

        //[ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<UserDto>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetAll()
        //{
        //    return GetResponseOnlyResult(await Mediator.Send(new GetUsersQuery()));
        //}

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<UserDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetTableSearch([FromQuery] TableGlobalFilter tableGlobalFilter)
        {
            GetUsersTableQuery getUsersQuery = new() { TableGlobalFilter = tableGlobalFilter };
            return GetResponseOnlyResult(await Mediator.Send(getUsersQuery));
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetUserQuery getUserQuery)
        {
            return GetResponseOnlyResult(await Mediator.Send(getUserQuery));
        }
    }
}
