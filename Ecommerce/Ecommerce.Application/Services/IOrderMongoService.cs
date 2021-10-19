using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public interface IOrderMongoService
    {
        public Task<bool> InsertRecord(Order order);
        public Task<List<Order>> LoadAll();
        public Task<Order> LoadByOrderId(Guid id);
        public Task<List<Order>> LoadByUserId(Guid userId);

    }
}
