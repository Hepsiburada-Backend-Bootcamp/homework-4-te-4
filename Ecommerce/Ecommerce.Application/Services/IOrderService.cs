using Ecommerce.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public interface IOrderService
    {
        Task<Guid> CreateOrder(CreateOrderDto dto);
        Task<List<OrderDto>> GetOrders();
        Task<OrderDto> GetOrder(Guid id);
        Task DeleteOrder(Guid id);
        Task<List<OrderDto>> GetOrdersOfUser(Guid userId);

        Task<bool> AddOrderItem(CreateOrderItemDto dto);
        Task<bool> RemoveOrderItem(Guid orderItemId);

        Task<bool> UpdateOrderItemQuantity(Guid orderItemId, int quantity);
        Task<bool> FinalizeOrder(Guid orderId);

    }
}
