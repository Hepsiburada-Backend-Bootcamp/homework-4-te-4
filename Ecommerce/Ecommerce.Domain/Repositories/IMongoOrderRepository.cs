using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public interface IMongoOrderRepository
    {
        Task<Order> FindByIdAsync(Guid id);
        Task<List<Order>> FindByUserIdAsync(Guid userId);
        Task<List<Order>> GetAllAsync();
        Task<bool> InsertRecordAsync(Order order);
    }
}