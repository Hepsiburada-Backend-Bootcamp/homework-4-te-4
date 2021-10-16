﻿using Dapper;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.DapperRepository
{
    class DapperOrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;

        public DapperOrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Guid> AddAsync(Order order)
        {
            //To-Do: User exists?

            order.Id = Guid.NewGuid();
            string addSql = "INSERT INTO Orders (Id,UserId,IsFinal) VALUES(@Id,@UserId,@IsFinal)";
            await _dbConnection.ExecuteAsync(addSql, order);

            string getSql = "SELECT Id FROM Orders WHERE UserId = @UserId AND IsFinal = @IsFinal ";
            return await _dbConnection.QuerySingleOrDefaultAsync<Guid>(getSql, order);
        }

        public async Task<bool> CreateOrderItem(OrderItem orderItem)
        {
            string productSql = "SELECT * FROM Products WHERE Id = @Id";
            var result = await _dbConnection.QuerySingleOrDefaultAsync<Product>(productSql, new { Id = orderItem.Product.Id });

            if (result == null || orderItem.Quantity <= 0)
            {
                return false;
            }



            orderItem.Id = Guid.NewGuid();
            //OrderItems - order-items tablo ismi uyusacak mi?
            string createSql = "INSERT INTO OrderItems (Id,OrderId,ProductId,Quantity) VALUES(@Id,@OrderId,@Product.Id,@Quantity)";
            await _dbConnection.ExecuteAsync(createSql, orderItem);

            return true;
        }

        public async Task DeleteAsync(Guid orderId)
        {
            string orderItemSql = "DELETE FROM OrderItems WHERE OrderId = @OrderId";
            await _dbConnection.ExecuteAsync(orderItemSql, new { OrderId = orderId });

            string orderSql = "DELETE FROM Orders WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(orderSql, new { Id = orderId });
            //return?
        }

        public async Task<bool> DeleteOrderItem(Guid orderItemId)
        {
            string checkSql = "SELECT * FROM OrderItems WHERE Id = @Id";
            var result = await _dbConnection.QuerySingleOrDefaultAsync<OrderItem>(checkSql, new { Id = orderItemId });

            if (result == null)
            {
                return false;
            }

            string deleteSql = "DELETE FROM OrderItems WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(deleteSql, new { Id = orderItemId });
            return true;
        }

        public async Task<bool> FinalizeOrder(Guid orderId)
        {
            Order order = await FindByIdAsync(orderId);

            if (order == null)
            {
                return false;
            }

            order.IsFinal = true;
            string sql = "UPDATE Orders SET IsFinal = @IsFinal WHERE Id=@Id";

            await _dbConnection.ExecuteAsync(sql, order);

            return true;
        }

        public async Task<Order> FindByIdAsync(Guid orderId)
        {
            string sql = "SELECT * FROM Orders WHERE Id = @Id";
            var result = await _dbConnection.QuerySingleOrDefaultAsync<Order>(sql, new { Id = orderId });
            return result;
        }

        public async Task<List<Order>> FindByUserIdAsync(Guid userId)
        {
            string sql = "SELECT * FROM Orders WHERE UserId = @UserId";
            var result = await _dbConnection.QueryAsync<Order>(sql, new { UserId = userId });
            return result.ToList();

        }

        public async Task<List<Order>> GetAllAsync()
        {
            string sql = "SELECT * FROM Orders";
            var result = await _dbConnection.QueryAsync<Order>(sql);
            return result.ToList();
        }

        public async Task<bool> UpdateOrderItemQuantity(Guid orderItemId, int quantity)
        {
            string sql = "UPDATE OrderItems SET Quantity = @Quantity WHERE Id=@Id";

            await _dbConnection.ExecuteAsync(sql, new { Id = orderItemId });

            return true;
        }
    }
}