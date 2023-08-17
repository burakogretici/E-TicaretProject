using Entities.Dtos.OperationClaims;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ApiHelper;

namespace Web.Controllers
{
    public class OperationClaimsController : Controller
    {
        private readonly IHttpClient _httpClient;
        public OperationClaimsController(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("operationclaim/index")]
        public async Task<IActionResult> Index()
        {
            var cate = await _httpClient.GetAsync<List<OperationClaimDto>>("OperationClaims/GetAll");
            return View(cate.Data);
        }

        [HttpGet("operationclaim/get")]
        public async Task<IActionResult> GetById(string id)
        {
            var cate = await _httpClient.GetAsync<OperationClaimDto>($"OperationClaims/GetById/{id}");
            return View(cate.Data);
        }

        [HttpGet("operationclaim/create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("operationclaim/create")]
        public async Task<IActionResult> Create(OperationClaimDto operationClaimDto)
        {
            var result = await _httpClient.PostAsync<OperationClaimDto>("OperationClaims/Add", operationClaimDto);
            return result.ToJson("/operationclaim/index");
        }

        [HttpGet("operationclaim/update")]
        public async Task<IActionResult> Update(string id)
        {
            var result = await _httpClient.GetAsync<OperationClaimDto>($"OperationClaims/GetById/{id}");
            if (result.Data == null)
            {
                //ModelState.AddModelError("", result.Message);
                //return View();
                return NotFound(result.Message);
            }
            return View(result.Data);
            //return new JsonResult(new { data = result});
        }

        [HttpPost("operationclaim/update")]
        public async Task<IActionResult> Update(OperationClaimDto operationClaimDto)
        {
            var result = await _httpClient.PutAsync<OperationClaimDto>("OperationClaims/Update/", operationClaimDto);
            return result.ToJson("/operationclaim/index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _httpClient.DeleteAsync<OperationClaimDto>($"OperationClaims/Delete/{id}");
            return result.ToJson();
        }
    }
}
