using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.DTOs.Categories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {

            var result = await _categoryService.GetAllAsync();
            return  result.Success ? Ok( result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid categoryId)
        {
            var result = await _categoryService.GetByIdAsync(categoryId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CategoryDto category)

        {
            var result = await _categoryService.AddAsync(category);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Category category)

        {
            var result = await _categoryService.UpdateAsync(category);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] Category category)

        {
            var result = await _categoryService.DeleteAsync(category);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
