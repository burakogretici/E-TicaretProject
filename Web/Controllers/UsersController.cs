
using Entities.Dtos.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ApiHelper;
using Web.Models;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IHttpClient _httpClient;
        protected readonly IServiceProvider _serviceProvider;


        public UsersController(IHttpClient httpClient, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _httpClient = httpClient;
        }


        [HttpGet("user/index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Read(TableGlobalFilterRequest tableGlobalFilter)
        {
            var users = await _httpClient.GetAsync<List<User_VM>>($"users/getall{tableGlobalFilter.ToQueryString()}");
            return users.ToGridResult(tableGlobalFilter);
        }


        [HttpGet("user/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var cate = await _httpClient.GetAsync<UserDto>($"Users/GetById/{id}");
            return View(cate.Data);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("user/create")]
        public async Task<IActionResult> Create(UserForRegister userForRegister)
        {
            var result = await _httpClient.PostAsync<UserDto>("auth/register/", userForRegister);
            return result.ToJson("/user/index");
        }

        public async Task<IActionResult> Update(string id)
        {
            var result = await _httpClient.GetAsync<UserDto>($"Users/GetById/{id}");
            if (result.Data == null)
            {
                return NotFound(result.Message);
            }
            return View(result.Data);
        }

        [HttpPost("user/update")]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            var result = await _httpClient.PutAsync<UserDto>("Users/Update/", userDto);
            return result.ToJson("/user/index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync<UserDto>($"Users/Delete/{id}");
            return result.ToJson();
        }
    }
}
