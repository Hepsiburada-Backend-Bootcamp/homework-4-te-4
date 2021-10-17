using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IProductRepository productRepository, IMapper mapper)
        {
            _repository = repository;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddOrderItem(CreateOrderItemDto dto)
        {
            //ToDo Gönderilen product daha önce eklenmiş mi kontrol edilebilir.

            Product product = await _productRepository.FindByIdAsync(dto.ProductId);
            if (product == null)
            {
                return false;
            }
            
            OrderItem orderItem = _mapper.Map<CreateOrderItemDto, OrderItem>(dto);
            //orderItem.Product = product;
            
            return await _repository.CreateOrderItem(orderItem);
        }

        public async Task<Guid> CreateOrder(CreateOrderDto dto)
        {
            Order order = _mapper.Map<CreateOrderDto, Order>(dto);
            return await _repository.AddAsync(order);
        }

        public async Task DeleteOrder(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<bool> FinalizeOrder(Guid orderId)
        {
            bool sqlFinalized = await _repository.FinalizeOrder(orderId);
            //TODO: mongo implement edilecek.
            bool mongoFinalized = true;

            return sqlFinalized && mongoFinalized;
        }

        public async Task<OrderDto> GetOrder(Guid id)
        {
            Order order = await _repository.FindByIdAsync(id);
            return _mapper.Map<Order, OrderDto>(order);
        }

        public async Task<List<OrderDto>> GetOrders()
        {
            List<Order> orders = await _repository.GetAllAsync();
            return _mapper.Map<List<Order>, List<OrderDto>>(orders);
        }

        public async Task<List<OrderDto>> GetOrdersOfUser(Guid userId)
        {
            List<Order> orders = await _repository.FindByUserIdAsync(userId);
            return _mapper.Map<List<Order>, List<OrderDto>>(orders);
        }

        public async Task<bool> RemoveOrderItem(Guid orderId, Guid orderItemId)
        {
            return await _repository.DeleteOrderItem(orderId, orderItemId);
        }

        public async Task<bool> UpdateOrderItemQuantity(Guid orderItemId, int quantity)
        {
            return await _repository.UpdateOrderItemQuantity(orderItemId, quantity);
        }
    }
}
