using System;
using System.Threading.Tasks;
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly IOrderMongoService _mongoService;

        public OrderController(IOrderService service, IOrderMongoService mongoService)
        {
            _service = service;
            _mongoService = mongoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] CreateOrderDto dto)
        {
            return Ok(await _service.CreateOrder(dto));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOrder([FromRoute]Guid id)
        {
            await _service.DeleteOrder(id);
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrder([FromRoute]Guid id)
        {
            return Ok(await _service.GetOrder(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _service.GetOrders());
        }
        
        [HttpGet("user/{userId:guid}")]
        public async Task<IActionResult> GetOrdersOfUser([FromRoute]Guid userId)
        {
            return Ok(await _service.GetOrdersOfUser(userId));
        }

        [HttpPost("{orderId:guid}")]
        public async Task<IActionResult> AddItemToOrder([FromRoute]Guid orderId, [FromBody] CreateOrderItemDto dto)
        {
            if(orderId == dto.OrderId)
                return Ok(await _service.AddOrderItem(dto));
            return BadRequest();
        }
        
        [HttpDelete("{orderId:guid}/{orderItemId:guid}")]
        public async Task<IActionResult> RemoveItemFromOrder([FromRoute]Guid orderId, [FromRoute]Guid orderItemId)
        {
            return Ok(await _service.RemoveOrderItem(orderId,orderItemId));
        }

        [HttpPatch("{orderId:guid}/{orderItemId:guid}")]
        public async Task<IActionResult> UpdateItemQuantity([FromRoute]Guid orderId, [FromRoute]Guid orderItemId, [FromQuery]int quantity)
        {
            //TODO: validate orderId
            return Ok(await _service.UpdateOrderItemQuantity(orderItemId,quantity));
        }

        [HttpPatch("{orderId:guid}")]
        public async Task<IActionResult> FinalizeOrder([FromRoute]Guid orderId)
        {
            return Ok(await _service.FinalizeOrder(orderId));
        }

        [HttpGet("records/user/{userId:guid}")]
        public async Task<IActionResult> LoadByUserId(Guid userId)
        {
            return Ok(await _mongoService.LoadByUserId(userId));
        }

        [HttpGet("records/order/{orderId:guid}")]
        public async Task<IActionResult> LoadByOrderId(Guid orderId)
        {
            return Ok(await _mongoService.LoadByOrderId(orderId));
        }
    }
}