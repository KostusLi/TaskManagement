using Entities;
using TaskManager.DTOs.Users;
using TaskManager.Services.Interfaces;

namespace TaskManager.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly List<User> _userContainer = new();

        public Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User(Guid.NewGuid(), dto.Name, dto.Email);

            _userContainer.Add(user);

            return Task.FromResult(ToDto(user));
        }

        public Task<UserDto?> UpdateAsync(UpdateUserDto dto, Guid id)
        {
            var user = _userContainer.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return Task.FromResult<UserDto?>(null);

            user.Name = dto.Name;
            user.Email = dto.Email;

            return Task.FromResult<UserDto?>(ToDto(user));
        }

        public Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = _userContainer.FirstOrDefault(g => g.Id == id);
            if (user == null) return Task.FromResult<UserDto?>(null);
            return Task.FromResult<UserDto?>(ToDto(user));
        }

        public Task<List<UserDto>> GetAllAsync()
        {
            return Task.FromResult(_userContainer.Select(ToDto).ToList());
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var user = _userContainer.FirstOrDefault(g => g.Id == id);
            if (user == null)
            {
                return Task.FromResult(false);
            }
            _userContainer.Remove(user);
            return Task.FromResult(true);
        }

        private static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

        }
    }
}
