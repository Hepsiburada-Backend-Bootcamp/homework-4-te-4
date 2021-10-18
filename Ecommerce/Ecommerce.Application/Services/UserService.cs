using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDto = Ecommerce.Domain.Dtos.UserDto;

namespace Ecommerce.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateUser(CreateUserDto dto)
        {
            User user = _mapper.Map<CreateUserDto, User>(dto);
            return await _repository.AddAsync(user);
        }

        public Task DeleteUser(Guid id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<UserDto> GetUser(Guid id)
        {
            User user = await _repository.FindByIdAsync(id);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<List<UserDto>> GetUsers()
        {
            List<User> users = await _repository.GetAllAsync();

            return _mapper.Map<List<User>, List<UserDto>>(users);
        }

        public async Task UpdateUser(Guid id, UpdateUserDto dto)
        {
            if (id != dto.Id)
            {
                throw new ApplicationException(id + "does not match the dto");
            }

            User user = await _repository.FindByIdAsync(id);
            user = _mapper.Map(dto, user);
            await _repository.UpdateAsync(user);
        }
    }
}
