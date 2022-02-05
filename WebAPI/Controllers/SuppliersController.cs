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
        ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService; 
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _supplierService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int supplierId)
        {
            var result = _supplierService.GetById(supplierId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Supplier supplier)

        {
            var result = _supplierService.Add(supplier);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Supplier supplier)

        {
            var result = _supplierService.Update(supplier);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Supplier supplier)

        {
            var result = _supplierService.Delete(supplier);

            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
