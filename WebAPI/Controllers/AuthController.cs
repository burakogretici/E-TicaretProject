﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Authorizations.Commands;

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
        public async Task<ActionResult> Login([FromBody] LoginUserCommand loginModel)
        {
            var result = await Mediator.Send(loginModel);
            return result.Success ? Ok(result) : Unauthorized(result.Message);
        }
    }
}

