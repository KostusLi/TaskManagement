using Entities;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.DTOs.Tasks;
using TaskManager.Services.Interfaces;

namespace TaskManager.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskDto> CreateAsync(CreateTaskDto dto)
        {
            var task = new TaskItem(Guid.NewGuid(), dto.Title, dto.Description, dto.Status, dto.DueDate,dto.ProjectId, dto.AssignedUserId);
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return ToDto(task);
        }

        public async Task<TaskDto?> UpdateAsync(UpdateTaskDto dto, Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return null;
            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Status = dto.Status;
            task.DueDate = dto.DueDate;
            task.AssignedUserId = dto.AssignedUserId;
            await _context.SaveChangesAsync();
            return ToDto(task);
        }

        public async Task<TaskDto?> GetByIdAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return null;
            return ToDto(task);
        }

        public async Task<List<TaskDto>> GetAllAsync()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return tasks.Select(ToDto).ToList();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        private static TaskDto ToDto(TaskItem task)
        {
            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                DueDate = task.DueDate,
                ProjectId = task.ProjectId,
                AssignedUserId = task.AssignedUserId,
            };
        }
    }
}