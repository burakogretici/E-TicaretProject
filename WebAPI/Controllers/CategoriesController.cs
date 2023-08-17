using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Categories.Commands;
using Business.Handlers.Categories.Queries;
using Entities.Dtos.Categories;
using Microsoft.AspNetCore.Http;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<CategoryDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<IActionResult> GetTableSearch([FromQuery] TableGlobalFilter tableGlobalFilter)
        {
            GetCategoriesTableQuery getCategoriesQuery = new() { TableGlobalFilter = tableGlobalFilter };
            return GetResponseOnlyResult(await Mediator.Send(getCategoriesQuery));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCategoryQuery getCategoryQuery)
        {
            return GetResponseOnlyResult(await Mediator.Send(getCategoryQuery));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategory)
        {
            return GetResponseOnlyResult(await Mediator.Send(createCategory));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategory)
        {
            return GetResponseOnlyResult(await Mediator.Send(updateCategory));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCategoryCommand deleteCategory)
        {
            return GetResponseOnlyResult(await Mediator.Send(deleteCategory));
        }
    }
}
