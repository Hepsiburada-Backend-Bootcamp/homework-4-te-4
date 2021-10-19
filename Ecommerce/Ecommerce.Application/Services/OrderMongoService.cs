using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class OrderMongoService : IOrderMongoService
    {
        private readonly IMongoOrderRepository _repository;

        public OrderMongoService(IMongoOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> InsertRecord(Order order)
        {
            return await _repository.InsertRecordAsync(order);            
        }

        public async Task<List<Order>> LoadAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Order> LoadByOrderId(Guid id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<List<Order>> LoadByUserId(Guid userId)
        {
            return await _repository.FindByUserIdAsync(userId);
        }
    }
}
