using Ecommerce.Domain.Dtos;
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
        public Task<bool> InsertRecord(OrderDto orderDto);
        public Task<List<OrderDto>> LoadAll();
        public Task<OrderDto> LoadByOrderId(Guid id);
        public Task<List<OrderDto>> LoadByUserId(Guid userId);

    }
}
