using Ecommerce.Domain.Models;
using MongoDB.Driver;

namespace Ecommerce.Infrastructure.Context
{
    public interface IOrderMongoContext
    {
        IMongoCollection<Order> Orders { get; }
    }
}