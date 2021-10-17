using Dapper;
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
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        }

        public async Task<Guid> AddAsync(Order order)
        {
            //To-Do: User exists?

            order.Id = Guid.NewGuid();
            string addSql = "INSERT INTO Orders (Id,User_Id,Is_Final) VALUES(@Id,@UserId,@IsFinal)";
            await _dbConnection.ExecuteAsync(addSql, order);

            string getSql = "SELECT Id FROM Orders WHERE User_Id = @UserId AND Is_Final = @IsFinal ";
            return await _dbConnection.QuerySingleOrDefaultAsync<Guid>(getSql, order);
        }

        public async Task<bool> CreateOrderItem(OrderItem orderItem)
        {
            string productSql = "SELECT * FROM Products WHERE Id = @Id";
            var result = await _dbConnection.QuerySingleOrDefaultAsync<Product>(productSql, new { Id = orderItem.ProductId });

            if (result == null || orderItem.Quantity <= 0)
            {
                return false;
            }

            orderItem.Id = Guid.NewGuid();
            //OrderItems - order-items tablo ismi uyusacak mi?
            string createSql = "INSERT INTO Order_Items (Id,Order_Id,Product_Id,Quantity) VALUES(@Id,@OrderId,@ProductId,@Quantity)";
            await _dbConnection.ExecuteAsync(createSql, orderItem);

            return true;
        }

        public async Task DeleteAsync(Guid orderId)
        {
            string orderItemSql = "DELETE FROM Order_Items WHERE Order_Id = @OrderId";
            await _dbConnection.ExecuteAsync(orderItemSql, new { OrderId = orderId });

            string orderSql = "DELETE FROM Orders WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(orderSql, new { Id = orderId });
            //return?
        }

        public async Task<bool> DeleteOrderItem(Guid orderId, Guid orderItemId)
        {
            //TODO: CHECK IF ORDERITEM BELONG TO ORDER
            string checkSql = "SELECT * FROM Order_Items WHERE Id = @Id";
            var result = await _dbConnection.QuerySingleOrDefaultAsync<OrderItem>(checkSql, new { Id = orderItemId });

            if (result == null)
            {
                return false;
            }

            string deleteSql = "DELETE FROM Order_Items WHERE Id = @Id";
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
            string sql = "UPDATE Orders SET Is_Final = @IsFinal WHERE Id=@Id";

            await _dbConnection.ExecuteAsync(sql, order);

            return true;
        }

        public async Task<Order> FindByIdAsync(Guid orderId)
        {
            string sql = "SELECT * FROM Orders WHERE Id = @Id";
            var result = await _dbConnection.QuerySingleOrDefaultAsync<Order>(sql, new { Id = orderId });

            result = await PropertyFiller(result);

            return result;
        }

        public async Task<List<Order>> FindByUserIdAsync(Guid userId)
        {
            string sql = "SELECT * FROM Orders WHERE User_Id = @UserId";
            var result = await _dbConnection.QueryAsync<Order>(sql, new { UserId = userId });

            for (int i = 0; i < result.Count(); i++)
            {
                result.ToList()[i] = await PropertyFiller(result.ToList()[i]);
            }


            return result.ToList();

        }

        public async Task<List<Order>> GetAllAsync()
        {
            string sql = "SELECT * FROM Orders";
            var result = await _dbConnection.QueryAsync<Order>(sql);

            for (int i = 0; i < result.Count(); i++)
            {
                result.ToList()[i] = await PropertyFiller(result.ToList()[i]);
            }


            return result.ToList();
        }

        public async Task<bool> UpdateOrderItemQuantity(Guid orderItemId, int quantity)
        {
            string sql = "UPDATE Order_Items SET Quantity = @Quantity WHERE Id=@Id";

            await _dbConnection.ExecuteAsync(sql, new { Id = orderItemId, Quantity=quantity });

            return true;
        }
        private async Task<Order> PropertyFiller(Order order)
        {

            string orderItemSql = "SELECT * FROM order_items WHERE order_id=@Id";
            var orderItems = await _dbConnection.QueryAsync<OrderItem>(orderItemSql, new { Id = order.Id });
            
            for (int i = 0; i < orderItems.Count(); i++)
            {
                string productSql = "SELECT * FROM products WHERE id=@Id";
                var product = await _dbConnection.QuerySingleOrDefaultAsync<Product>(productSql, new { Id = orderItems.ToList()[i].ProductId });
                orderItems.ToList()[i].Product = product;
            }

            order.Items = orderItems.ToList();
            return order;
        }

    }
}
