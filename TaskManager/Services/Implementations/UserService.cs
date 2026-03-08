using Entities;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.DTOs.Users;
using TaskManager.Services.Interfaces;

namespace TaskManager.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User(Guid.NewGuid(), dto.Name, dto.Email);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return ToDto(user);
        }

        public async Task<UserDto?> UpdateAsync(UpdateUserDto dto, Guid id)
        {
            var user =  await _context.Users.FindAsync(id);
            if (user == null) return null;
            user.Name = dto.Name;
            user.Email = dto.Email;
            await _context.SaveChangesAsync();
            return ToDto(user);
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;
            return ToDto(user);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            return (await _context.Users.ToListAsync())
                .Select(ToDto)
                .ToList();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
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
