using System;
using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserDto dto)
        {
            return Ok(await _service.CreateUser(dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]Guid id)
        {
            await _service.DeleteUser(id);
            return Ok();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute]Guid id)
        {
            return Ok(await _service.GetUser(id));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _service.GetUsers());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute]Guid id, [FromBody]UpdateUserDto dto)
        {
            await _service.UpdateUser(id, dto);
            return Ok();
        }
    }
}