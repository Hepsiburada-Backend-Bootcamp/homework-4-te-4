using Ecommerce.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public interface IUserService
    {
        Task<Guid> CreateUser(CreateUserDto dto);
        Task<List<UserDto>> GetUsers();
        Task<UserDto> GetUser(Guid id);
        Task DeleteUser(Guid id);
        Task UpdateUser(Guid id, UpdateUserDto dto);
    }
}
