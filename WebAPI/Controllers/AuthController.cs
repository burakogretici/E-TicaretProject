using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Abstract.UserService;
using Core.Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Users;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;

        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] UserForRegister userForRegister)
        {
            var userExists = _authService.UserExits(userForRegister.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegister, userForRegister.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserForLogin userForLogin)
        {
            var userLogin = _authService.Login(userForLogin);
            if (!userLogin.Success)
            {
                return BadRequest(userLogin.Message);
            }

            var result = _authService.CreateAccessToken(userLogin.Data);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

