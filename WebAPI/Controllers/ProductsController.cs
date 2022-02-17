using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTOs;

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
        public async Task<IActionResult> GetById(int productId)
        {
            var result = await _productService.GetByIdAsync(productId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbycategorydid")]
        public async Task<IActionResult> GetAllByCategoryId(int categoryId)
        {
            var result = await _productService.GetAllByCategoryIdAsync(categoryId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ProductDto model)

        {
            var result = _productService.Add(model);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyunitprice")]
        public async Task<IActionResult> GetByUnitPrice(decimal min, decimal max)
        {
            var result = await _productService.GetByUnitPriceAsync(min, max);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)

        {
            var result = _productService.Update(product);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Product product)

        {
            var result = _productService.Delete(product);
            return result.Success ? Ok(result) : BadRequest(result);

        }

        [HttpGet("getproductdetail")]
        public IActionResult GetProductDetail()
        {
            var result = _productService.GetProductDetails();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}