using System.Threading.Tasks;
using Entities.Dtos.Menus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.ApiHelper;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenusController : Controller
    {
        private readonly IApiHelper _apiHelper;

        public MenusController(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<IActionResult> Index()
        {
            var menus = await _apiHelper.Get<MenuDto>("menus/getall");
            return View(menus);
        }
        [HttpGet("menus/update")]
        public async Task<IActionResult> Update(string id)
        {
            var menu = await _apiHelper.GetById<MenuDto>($"menus/{id}");
            return View(menu);
        }

        [HttpPost("menus/update")]
        public async Task<IActionResult> Update(MenuDto menu)
        {
            await _apiHelper.Put<MenuDto>("menus/update", menu);
            return RedirectToAction("Index");
        }

        public IActionResult GetById()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("menus/delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await _apiHelper.Delete<MenuDto>($"menus/delete/{id}");
            return RedirectToAction("Index");
        }

        [HttpGet("menus/create")]
        public async Task<IActionResult> Create()
        {
            var menus = await _apiHelper.Get<MenuDto>("menus/getall");
            ViewBag.Menus = new SelectList(menus, "Id", "Name");
            return View();
        }

        [HttpPost("menus/create")]
        public async Task<IActionResult> Create(MenuDto menuDto)
        {
            await _apiHelper.Post<MenuDto>("menus/add", menuDto);
            return RedirectToAction("Index");
        }
    }
}
