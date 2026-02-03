using TaskManager.DTOs.Tasks;

namespace TaskManager.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDto> CreateAsync(CreateTaskDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<List<TaskDto>> GetAllAsync();
        Task<TaskDto?> GetByIdAsync(Guid id);
        Task<TaskDto?> UpdateAsync(UpdateTaskDto dto, Guid id);
    }
}