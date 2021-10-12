using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Guid> AddAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product> FindByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Product product);
    }
}