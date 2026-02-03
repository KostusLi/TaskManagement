using TaskManager.DTOs.Users;

namespace TaskManager.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(Guid id);
        Task<UserDto?> UpdateAsync(UpdateUserDto dto, Guid id);
    }
}