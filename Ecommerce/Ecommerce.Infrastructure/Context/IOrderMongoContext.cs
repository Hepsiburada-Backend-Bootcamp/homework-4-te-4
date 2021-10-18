using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Models;
using MongoDB.Driver;

namespace Ecommerce.Infrastructure.Context
{
    public interface IOrderMongoContext
    {
        IMongoCollection<OrderDto> Orders { get; }
    }
}