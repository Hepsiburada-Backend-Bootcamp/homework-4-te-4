using System;
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        /*[HttpPost]
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
        */
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_service.GetUsers());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute]Guid id, [FromBody]UpdateUserDto dto)
        {
            return Ok(_service.UpdateUser(id,dto));
        }
    }
}