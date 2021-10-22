using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public interface IMongoOrderRepository
    {
        Task<OrderDto> FindByIdAsync(Guid id);
        Task<List<OrderDto>> FindByUserIdAsync(Guid userId);
        Task<List<OrderDto>> GetAllAsync();
        Task<bool> InsertRecordAsync(OrderDto orderDto);
    }
}