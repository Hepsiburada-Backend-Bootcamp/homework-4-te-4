using Ecommerce.Domain.Models;
using MongoDB.Driver;

namespace Ecommerce.Infrastructure.Context
{
    public class OrderMongoContext : IOrderMongoContext
    {
        public OrderMongoContext(IOrderDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Orders = database.GetCollection<Order>(settings.CollectionName);
        }
        public IMongoCollection<Order> Orders { get; }
    }
}