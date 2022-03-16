using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.DTOs.Products;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid productId)
        {
            var result = await _productService.GetByIdAsync(productId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbycategorydid")]
        public async Task<IActionResult> GetAllByCategoryId(Guid categoryId)
        {
            var result = await _productService.GetAllByCategoryIdAsync(categoryId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductDto model)

        {
            var result = await _productService.AddAsync(model);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyunitprice")]
        public async Task<IActionResult> GetByUnitPrice(decimal min, decimal max)
        {
            var result = await _productService.GetByUnitPriceAsync(min, max);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Product product)

        {
            var result = await _productService.UpdateAsync(product);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] Product product)

        {
            var result = await _productService.DeleteAsync(product);
            return result.Success ? Ok(result) : BadRequest(result);

        }

        [HttpGet("getproductdetail")]
        public async Task<IActionResult> GetProductDetail()
        {
            var result =  await _productService.GetProductDetails();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}