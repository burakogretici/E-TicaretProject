using Business.Abstract.UserService;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyemail")]
        public IActionResult GetByMail(string email)
        {
            var result = _userService.GetByMail(email);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
