using Entities;
using TaskManager.DTOs.Tasks;
using TaskManager.Services.Interfaces;

namespace TaskManager.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskItem> _tasks = new();

        public Task<TaskDto> CreateAsync(CreateTaskDto dto)
        {
            var task = new TaskItem(Guid.NewGuid(), dto.Title, dto.Description, dto.Status, dto.DueDate,dto.ProjectId, dto.AssignedUserId);
            _tasks.Add(task);
            return Task.FromResult(ToDto(task));
        }

        public Task<TaskDto?> UpdateAsync(UpdateTaskDto dto, Guid id)
        {
            int i = _tasks.FindIndex(t => t.Id == id);
            if (i == -1)
            {
                return Task.FromResult<TaskDto?>(null);
            }
            _tasks[i].Title = dto.Title;
            _tasks[i].Description = dto.Description;
            _tasks[i].Status = dto.Status;
            _tasks[i].DueDate = dto.DueDate;
            _tasks[i].AssignedUserId = dto.AssignedUserId;
            return Task.FromResult<TaskDto?>(ToDto(_tasks[i]));
        }

        public Task<TaskDto?> GetByIdAsync(Guid id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return Task.FromResult<TaskDto?>(null);
            return Task.FromResult<TaskDto?>(ToDto(task));
        }

        public Task<List<TaskDto>> GetAllAsync()
        {
            return Task.FromResult(_tasks.Select(ToDto).ToList());
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var task = _tasks.FirstOrDefault(g => g.Id == id);
            if (task == null) return Task.FromResult(false);
            _tasks.Remove(task);
            return Task.FromResult(true);
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
