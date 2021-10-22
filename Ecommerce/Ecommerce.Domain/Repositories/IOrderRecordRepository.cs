using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public interface IOrderRecordRepository
    {
        Task<OrderDto> LoadByIdAsync(Guid id);
        Task<List<OrderDto>> LoadByUserIdAsync(Guid userId);
        Task<List<OrderDto>> LoadAllAsync();
        Task<bool> InsertRecordAsync(OrderDto orderDto);
    }
}