using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> AddAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User> FindByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(User user);
    }
}