using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infrastructure.Context;
using Microsoft.Extensions.Configuration;



namespace Ecommerce.Infrastructure.DapperRepository
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _context;

        public DapperProductRepository(IDbConnection dbContext)
        {
            _context = dbContext;
        }
        public async Task<Guid> AddAsync(Product product)
        {
            string sql = "INSERT INTO Products (Name) VALUES(@Name)";
            //id geri naıl döndüreceğiz?
            
            return await _context.ExecuteAsync(sql,product);
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}