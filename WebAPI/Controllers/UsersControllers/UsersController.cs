using Business.Abstract.UserService;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace WebAPI.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] User user)
        {
            var result = await _userService.AddAsync(user);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] User user)
        {
            var result = await _userService.DeleteAsync(user);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            var result = await _userService.UpdateAsync(user);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyemail")]
        public async Task<IActionResult> GetByMail(string email)
        {
            var result = await _userService.GetByMail(email);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
