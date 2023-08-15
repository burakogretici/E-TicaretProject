using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
