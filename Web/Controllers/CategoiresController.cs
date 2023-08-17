using Entities.Dtos.Categories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ApiHelper;
using Web.Models;

namespace Web.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(IHttpClient httpClient) : base(httpClient) { }

        [HttpGet("category/index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Read(TableGlobalFilterRequest tableGlobalFilter)
        {
            var categories = await _httpClient.GetAsync<List<Category_VM>>($"categories/getall{tableGlobalFilter.ToQueryString()}");
            return categories.ToGridResult(tableGlobalFilter);
        }

        [HttpGet("category/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var cate = await _httpClient.GetAsync<CategoryDto>($"categories/{id}");
            return View(cate.Data);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("category/create")]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {

            var result = await _httpClient.PostAsync<CategoryDto>("categories/add", categoryDto);
            return result.ToJson("/category/index");
        }

        public async Task<IActionResult> Update(string id)
        {
            var result = await _httpClient.GetAsync<CategoryDto>($"categories/{id}");
            if (result.Data == null)
            {
                return NotFound(result.Message);
            }
            return View(result.Data);
        }

        [HttpPost("category/update")]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            var result = await _httpClient.PutAsync<CategoryDto>("categories/update", categoryDto);
            return result.ToJson("/category/index");
        }

        public async Task<IActionResult> Delete(string id)
        {

            var result = await _httpClient.DeleteAsync<CategoryDto>($"categories/delete/{id}");
            return result.ToJson();
        }
    }
}