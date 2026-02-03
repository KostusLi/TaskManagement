using Microsoft.AspNetCore.Mvc;
using TaskManager.DTOs.Projects;
using TaskManager.Services.Interfaces;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetAll()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetById(Guid id) { 
            var project = await _projectService.GetByIdAsync(id);
            if(project == null) return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> Create(CreateProjectDto dto)
        {
            var project = await _projectService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new {id=project.Id}, project);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectDto>> Update(UpdateProjectDto dto, Guid id) { 
            var project = await _projectService.UpdateAsync(dto, id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) { 
            bool check = await _projectService.DeleteAsync(id);
            if(!check) return NotFound();
            return NoContent();
        }
    }
}
