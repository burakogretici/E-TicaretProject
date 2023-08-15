using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Dtos.Menus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.ApiHelper;

namespace Web.Controllers
{
    public class MenusController : BaseController
    {
        public MenusController(IHttpClient httpClient) : base(httpClient) { }

        [HttpGet("menus/index")]
        public async Task<IActionResult> Index()
        {
            var menus = await _httpClient.GetAsync<List<MenuDto>>("menus/getall");
            return View(menus.Data);
        }
        [HttpGet("menus/update")]
        public async Task<IActionResult> Update(string id)
        {
            var menus = await _httpClient.GetAsync<List<MenuDto>>("menus/getall");
            ViewBag.Menus = new SelectList(menus.Data, "Id", "Name");

            var menu = await _httpClient.GetAsync<MenuDto>($"menus/{id}");
            return View(menu.Data);
        }

        [HttpPost("menus/update")]
        public async Task<IActionResult> Update(MenuDto menu)
        {
            var result = await _httpClient.PutAsync<MenuDto>("menus/update", menu);
            return result.ToJson("/menus/index");
        }

        public async Task<IActionResult> GetById(string id)
        {
            var menu = await _httpClient.GetAsync<MenuDto>($"menus/{id}");
            return View(menu.Data);
        }

        [HttpGet("menus/delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync<MenuDto>($"menus/delete/{id}");
            return result.ToJson("/menus/index");

        }

        [HttpGet("menus/create")]
        public async Task<IActionResult> Create()
        {
            var menus = await _httpClient.GetAsync<List<MenuDto>>("menus/getall");
            ViewBag.Menus = new SelectList(menus.Data, "Id", "Name");
            return View();
        }

        [HttpPost("menus/create")]
        public async Task<IActionResult> Create(MenuDto menuDto)
        {
            var result = await _httpClient.PostAsync<MenuDto>("menus/add", menuDto);
            return result.ToJson("/menus/index");
        }
    }
}
