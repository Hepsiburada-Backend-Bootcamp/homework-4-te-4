using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Ecommerce.Infrastructure.DapperRepository
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public DapperProductRepository(IDbConnection dbContext)
        {
            _dbConnection = dbContext;
        }
        public async Task<Guid> AddAsync(Product product)
        {

            product.Id = Guid.NewGuid();
            string addSql = "INSERT INTO Products (Id,Name,Brand,Price) VALUES(@Id,@Name,@Brand,@Price)";
            await _dbConnection.ExecuteAsync(addSql, product);

            string getSql = "SELECT Id FROM Products WHERE Name = @Name AND Brand = @Brand AND Price = @Price";
            return await _dbConnection.QuerySingleOrDefaultAsync<Guid>(getSql, product);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            string sql = "SELECT * FROM Products";
            var result = await _dbConnection.QueryAsync<Product>(sql);
            return result.ToList();
        }

        public async Task<Product> FindByIdAsync(Guid id)
        {
            string sql = "SELECT * FROM Products WHERE Id = @Id";
            var result = await _dbConnection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
            return result;
        }

        public Task DeleteAsync(Guid id)
        {
            string sql = "DELETE FROM Products WHERE Id = @Id";
            return _dbConnection.ExecuteAsync(sql, new { Id = id });

        }

        public Task UpdateAsync(Product product)
        {
            string sql = "UPDATE Products SET Name = @Name , Brand = @Brand , Price = @Price WHERE Id = @Id ";
            return _dbConnection.ExecuteAsync(sql, product);
        }
    }
}