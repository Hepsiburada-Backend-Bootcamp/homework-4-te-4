using System;
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
        public IActionResult AddProduct([FromBody] CreateProductDto dto)
        {
            return Ok(_service.CreateProduct(dto));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute]Guid id)
        {
            return Ok(_service.DeleteProduct(id));
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute]Guid id)
        {
            return Ok(_service.GetProduct(id));
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_service.GetProducts());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromRoute]Guid id, [FromBody]UpdateProductDto dto)
        {
            return Ok(_service.UpdateProduct(id,dto));
        }
    }
}