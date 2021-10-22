using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class OrderRecordService : IOrderRecordService
    {
        private readonly IOrderRecordRepository _recordRepository;

        public OrderRecordService(IOrderRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }
        public async Task<bool> InsertRecord(OrderDto orderDto)
        {
            return await _recordRepository.InsertRecordAsync(orderDto);            
        }

        public async Task<List<OrderDto>> LoadAll()
        {
            return await _recordRepository.LoadAllAsync();
        }

        public async Task<OrderDto> LoadByOrderId(Guid id)
        {
            return await _recordRepository.LoadByIdAsync(id);
        }

        public async Task<List<OrderDto>> LoadByUserId(Guid userId)
        {
            return await _recordRepository.LoadByUserIdAsync(userId);
        }
    }
}
