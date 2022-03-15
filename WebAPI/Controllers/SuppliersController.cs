using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _supplierService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid supplierId)
        {
            var result = await _supplierService.GetByIdAsync(supplierId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Supplier supplier)

        {
            var result = await _supplierService.AddAsync(supplier);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Supplier supplier)

        {
            var result = await _supplierService.UpdateAsync(supplier);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] Supplier supplier)

        {
            var result = await _supplierService.DeleteAsync(supplier);

            return  result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
