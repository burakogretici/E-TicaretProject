using System.Threading.Tasks;
using Business.Handlers.Users.Commands;
using Business.Handlers.Users.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserCommand createUser)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createUser));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand deleteUser)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteUser));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUser)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateUser));
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetUsersQuery()));
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetUserQuery getUserQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getUserQuery));
        }
    }
}
