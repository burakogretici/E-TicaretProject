using Entities.Dtos.OperationClaims;
using Entities.Dtos.UserOperationClaim;
using Entities.Dtos.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ApiHelper;

namespace Web.Controllers
{
    public class UserOperationClaimsController : Controller
    {
        private readonly IHttpClient _httpClient;
        public UserOperationClaimsController(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("useroperationclaim/index")]
        public async Task<IActionResult> Index()
        {
            var userOperationClaims = await _httpClient.GetAsync<List<UserOperationClaimDto>>("UserOperationClaims/GetAll");
            var groupedUserOperationClaims = userOperationClaims.Data.GroupBy(u => u.UserId).Select(g => g.First()).ToList();

            return View(groupedUserOperationClaims);
        }

        [HttpGet("useroperationclaim/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var userOperationClaim = await _httpClient.GetAsync<UserOperationClaimDto>($"UserOperationClaims/GetById/{id}");
            return View(userOperationClaim.Data);
        }

        [HttpGet("useroperationclaim/getUserRoles")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var userOperationClaim = await _httpClient.GetAsync<UserOperationClaimListDto>($"UserOperationClaims/GetByIdUserOperationClaim/{userId}");
            return Json(userOperationClaim.Data);

        }

        [HttpGet("useroperationclaim/create")]
        public async Task<IActionResult> Create()
        {
            await SetProperties();
            return View();
        }

        [HttpPost("useroperationclaim/create")]
        public async Task<IActionResult> Create(UserOperationClaimDto operationClaimDto)
        {
            var result = await _httpClient.PostAsync<UserOperationClaimDto>("UserOperationClaims/Add", operationClaimDto);
            return result.ToJson("/useroperationclaim/index");
        }

        [HttpGet("useroperationclaim/update")]
        public async Task<IActionResult> Update(string id)
        {
            await SetProperties();
            var result = await _httpClient.GetAsync<UserOperationClaimDto>($"UserOperationClaims/GetById/{id}");
            if (result.Data == null)
            {
                return NotFound(result.Message);
            }
            return View(result.Data);
        }

        [HttpPost("useroperationclaim/update")]
        public async Task<IActionResult> Update(UserOperationClaimDto operationClaimDto)
        {
            var result = await _httpClient.PutAsync<UserOperationClaimDto>("UserOperationClaims/Update/", operationClaimDto);
            return result.ToJson("/useroperationclaim/index");
        }

        [HttpPost("useroperationclaim/delete")]
        public async Task<IActionResult> Delete(string userId,List<string> roleIds)
        {
           var queryString = string.Join("&", roleIds.Select(id => $"roleIds={id}"));
            var result = await _httpClient.DeleteAsync<UserOperationClaimDto>($"UserOperationClaims/Delete?userId={userId}&{queryString}");
            return result.ToJson("/useroperationclaim/index");

        }
        private async Task SetProperties()
        {
            var users = await _httpClient.GetAsync<List<UserDto>>("users/getall");
            ViewBag.Users = new SelectList(users.Data, "Id", "FullName");

            var operationClaims = await _httpClient.GetAsync<List<OperationClaimDto>>("OperationClaims/GetAll");
            ViewBag.OperationClaims = new SelectList(operationClaims.Data, "Id", "Name");


        }
    }
}
