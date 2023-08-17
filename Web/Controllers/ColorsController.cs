using Entities.Dtos.Colors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ApiHelper;
using Web.Models;

namespace Web.Controllers
{
    public class ColorsController : BaseController
    {
        public ColorsController(IHttpClient httpClient) : base(httpClient) { }

        [HttpGet("color/index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Read(TableGlobalFilterRequest tableGlobalFilter)
        {
            var colors = await _httpClient.GetAsync<List<Color_VM>>($"colors/getall{tableGlobalFilter.ToQueryString()}");
            return colors.ToGridResult(tableGlobalFilter);
        }
        [HttpGet("color/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var color = await _httpClient.GetAsync<ColorDto>($"colors/{id}");
            return View(color.Data);

        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("color/create")]
        public async Task<IActionResult> Create(ColorDto colorDto)
        {
            var result = await _httpClient.PostAsync<ColorDto>("colors/add", colorDto);
            return result.ToJson("/color/index");
        }

        public async Task<IActionResult> Update(string id)
        {
            var color = await _httpClient.GetAsync<ColorDto>($"colors/{id}");
            return View(color.Data);
        }

        [HttpPost("color/update")]
        public async Task<IActionResult> Update(ColorDto colorDto)
        {
            var result = await _httpClient.PutAsync<ColorDto>("colors/update", colorDto);
            return result.ToJson("/color/index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync<ColorDto>($"colors/delete/{id}");
            return result.ToJson();
        }
    }
}
