using Microsoft.AspNetCore.Mvc;
using TaskManager.DTOs.Tasks;
using TaskManager.Services.Interfaces;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDto>>> GetAll()
        {
            var tasks = await _taskService.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetById(Guid id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> Create(CreateTaskDto dto)
        {
            var task = await _taskService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskDto>> Update(UpdateTaskDto dto, Guid id)
        {
            var task = await _taskService.UpdateAsync(dto, id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool check = await _taskService.DeleteAsync(id);
            if (!check) return NotFound();
            return NoContent();
        }
    }
}
