using Microsoft.AspNetCore.Mvc;
using Web.ApiHelper;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IHttpClient _httpClient;

        public BaseController(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       
    }
}
