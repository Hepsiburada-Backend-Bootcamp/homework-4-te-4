using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infrastructure.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ecommerce.Infrastructure.MongoRepository
{
    public class OrderMongoRepository : IOrderRecordRepository
    {
        IOrderMongoContext _context;

        public OrderMongoRepository(IOrderMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertRecordAsync(OrderDto orderDto)
        {
            await _context.Orders.InsertOneAsync(orderDto);
            return true;
        }
        
        public async Task<List<OrderDto>> LoadAllAsync()
        {
            return await _context.Orders.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<OrderDto> LoadByIdAsync(Guid id)
        {
            //Use filters if fails
            return await _context.Orders.Find(o => o.Id == id).FirstAsync();
        }

        public async Task<List<OrderDto>> LoadByUserIdAsync(Guid userId)
        {
            return await _context.Orders.Find(o => o.UserId == userId).ToListAsync();
        }

    }
}