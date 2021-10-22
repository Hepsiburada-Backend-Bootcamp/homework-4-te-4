using System;
using System.Threading.Tasks;
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductDto dto)
        {
            return Ok(await _service.CreateProduct(dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]Guid id)
        {
            await _service.DeleteProduct(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute]Guid id)
        {
            var result = await _service.GetProduct(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _service.GetProducts());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]Guid id, [FromBody]UpdateProductDto dto)
        {
            await _service.UpdateProduct(id, dto);
            return Ok();
        }
    }
}