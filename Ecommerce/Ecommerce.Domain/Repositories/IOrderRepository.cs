using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Guid> AddAsync(Order order);
        Task<List<Order>> GetAllAsync();
        Task<Order> FindByIdAsync(Guid orderId);
        Task DeleteAsync(Guid orderId);
        Task<List<Order>> FindByUserIdAsync(Guid userId);

        //No adding or subtracting
        Task<bool> CreateOrderItem(OrderItem orderItem);
        Task<bool> DeleteOrderItem(Guid orderId, Guid orderItemId);

        //Check if orderItem exists, update quantity
        Task<bool> UpdateOrderItemQuantity(Guid orderItemId, int quantity);
        Task<bool> FinalizeOrder(Guid orderId);

    }
}