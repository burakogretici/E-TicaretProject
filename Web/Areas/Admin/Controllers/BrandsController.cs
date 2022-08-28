using DataAccess.Concrete.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Threading.Tasks;


namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly EticaretContext _contextDb;

        public BrandsController(EticaretContext contextDb)
        {
            _contextDb = contextDb;
        }

        public async Task<IActionResult> GetAll()
        {
            var brands = await _contextDb.Brands.ToListAsync();
            return View(brands);
        }
    }
}