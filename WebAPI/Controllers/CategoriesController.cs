using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Handlers.Categories.Commands;
using Business.Handlers.Categories.Queries;
using Core.Utilities.Results;
using Entities.Dtos.Categories;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<CategoryDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetCategoriesQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCategoryQuery getCategoryQuery)
        {
            return GetResponseOnlyResultData(await Mediator.Send(getCategoryQuery));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategory)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createCategory));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategory)

        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateCategory));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCategoryCommand deleteCategory)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteCategory));
        }
    }
}
