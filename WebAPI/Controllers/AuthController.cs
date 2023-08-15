using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Authorizations.Commands;
using Business.Handlers.Authorizations.Queries;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand createUser)
        {
            return GetResponseOnlyResult(await Mediator.Send(createUser));
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserQuery loginModel)
        {
            var result = await Mediator.Send(loginModel);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

