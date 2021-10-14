using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.EFRepository
{
    
    public class EFUserRepository : IUserRepository
    {
        private readonly EcommerceDbContext _dbContext;
        DbSet<User> _dbSet;
        public EFUserRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<User>();
        }
        public async Task<Guid> AddAsync(User user)
        {
            await _dbSet.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

        public Task<List<User>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
           // return _dbSet.Where(u => u.Id == id).FirstOrDefaultAsync();
           return await _dbContext.Users.FindAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            User user =await FindByIdAsync(id);
            _dbSet.Remove(user);
            //daha sonra bakılacak!!
            await _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(User user)
        {
           _dbSet.Remove(user);
           return _dbContext.SaveChangesAsync();
        }
    }
}