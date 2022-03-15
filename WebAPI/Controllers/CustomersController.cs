using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid customerId)
        {
            var result = await _customerService.GetByIdAsync(customerId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Customer customer)

        {
            var result = await _customerService.AddAsync(customer);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Customer customer)

        {
            var result = await _customerService.UpdateAsync(customer);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] Customer customer)

        {
            var result = await _customerService.DeleteAsync(customer);
            return result.Success ? Ok(result) : BadRequest(result);

        }
    }
}

