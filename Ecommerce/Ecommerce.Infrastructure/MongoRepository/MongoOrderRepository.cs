using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Infrastructure.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ecommerce.Infrastructure.MongoRepository
{
    public class MongoOrderRepository
    {
        IOrderMongoContext _context;

        public MongoOrderRepository(IOrderMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertRecordAsync(Order order)
        {
            await _context.Orders.InsertOneAsync(order);
            return true;
        }
        
        //TODO: RENAME
        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.Find(new BsonDocument()).ToListAsync();
        }
        
        public async Task<Order> FindByIdAsync(Guid id)
        {
            //Use filters if fails
            return await _context.Orders.Find(o => o.Id == id).FirstAsync();
        }
        
        public async Task<List<Order>> FindByUserIdAsync(Guid userId)
        {
            return await _context.Orders.Find(o => o.UserId == userId).ToListAsync();
        }
        
    }
}