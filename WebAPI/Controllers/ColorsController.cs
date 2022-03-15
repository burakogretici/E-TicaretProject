using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Colors;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _colorService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid colorId)
        {
            var result =  await _colorService.GetByIdAsync(colorId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ColorDto color)
        {
            var result = await _colorService.AddAsync(color);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Color color)

        {
            var result = await _colorService.UpdateAsync(color);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] Color color)

        {
            var result = await _colorService.DeleteAsync(color);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}

