using Entities.Dtos.Categories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ApiHelper;

[Area("Admin")]
public class CategoiresController : Controller
{
    private readonly IApiHelper _apiHelper;

    public CategoiresController(IApiHelper apiHelper)
    {
        _apiHelper = apiHelper;
    }

 
    [HttpGet("category/index")]
    public async Task<IActionResult> Index()
    {
        var categories = await _apiHelper.Get<CategoryDto>("categories/getall");
        return View(categories);
    }
    [HttpGet("category/get")]
    public async Task<IActionResult> GetById(string id)
    {
        var category = await _apiHelper.GetById<CategoryDto>($"categories/{id}");
        return View(category);

    }

    [HttpGet("category/create")]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost("category/create")]
    public async Task<IActionResult> Create(CategoryDto categoryDto)
    {

        await _apiHelper.Post<CategoryDto>("categories/add", categoryDto);

        return RedirectToAction("Index");
    }

    [HttpGet("category/update")]
    public async Task<IActionResult> Update(string id)
    {
        var category = await _apiHelper.GetById<CategoryDto>($"categories/{id}");
        return View(category);
    }

    [HttpPost("category/update")]
    public async Task<IActionResult> Update(CategoryDto categoryDto)
    {
        await _apiHelper.Put<CategoryDto>("categories/update", categoryDto);
        return RedirectToAction("Index");
    }

    [HttpGet("category/delete")]
    public async Task<IActionResult> Delete(string id)
    {
        await _apiHelper.Delete<CategoryDto>($"categories/delete/{id}");
        return RedirectToAction("Index");
    }
}