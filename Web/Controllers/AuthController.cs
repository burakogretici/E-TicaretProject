using Business.Helpers.Jwt;
using Business.Services;
using Entities.Dtos.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Web.ApiHelper;

namespace Web.Controllers
{

    public class AuthController : BaseController
    {
        private readonly IUserAccessor _userAccessor;

        public AuthController(IHttpClient httpClient, IUserAccessor userAccessor) : base(httpClient)
        {
            _userAccessor = userAccessor;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserForLogin model, string returnUrl)
        {

            if (!string.IsNullOrEmpty(returnUrl))
            {
                if (returnUrl.StartsWith("http:"))
                {
                    returnUrl = "";
                }
            }

            ViewBag.ReturnUrl = returnUrl;

            var result = await _httpClient.PostAsync<AccessToken>("auth/login/", model);


            if (result.Success)
            {
                _userAccessor.User = result.Data.User;
                _userAccessor.Store("Token", result.Data.Token);
                _userAccessor.Store("Expiration", result.Data.Expiration);
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }

            if (string.IsNullOrEmpty(returnUrl))
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return Redirect(returnUrl);
            }

        }

        [AllowAnonymous]
        public IActionResult Logout()
        {
            _userAccessor.Clear("CurrentUser");
            _userAccessor.Clear("Token");
            return Redirect("/");
        }
    }
}
