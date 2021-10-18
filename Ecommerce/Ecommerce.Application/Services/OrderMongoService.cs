using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class OrderMongoService : IOrderMongoService
    {
        private readonly IOrderMongoService _service;

        public OrderMongoService(IOrderMongoService service)
        {
            _service = service;
        }
        public async Task<bool> InsertRecord(Order order)
        {
            return await _service.InsertRecord(order);            
        }

        public async Task<List<Order>> LoadAll()
        {
            return await _service.LoadAll();
        }

        public async Task<Order> LoadByOrderId(Guid id)
        {
            return await _service.LoadByOrderId(id);
        }

        public async Task<List<Order>> LoadByUserId(Guid userId)
        {
            return await _service.LoadByUserId(userId);
        }
    }
}
