using Entities;
using TaskManager.DTOs.Projects;
using TaskManager.Services.Interfaces;

namespace TaskManager.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly List<Project> _projects = new();

        public Task<ProjectDto> CreateAsync(CreateProjectDto dto)
        {
            var project = new Project(Guid.NewGuid(), dto.Name, dto.Description, dto.OwnerUserId);
            _projects.Add(project);
            return Task.FromResult(ToDto(project));
        }

        public Task<ProjectDto?> UpdateAsync(UpdateProjectDto dto, Guid id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id);
            if (project == null) return Task.FromResult<ProjectDto?>(null);
            project.Name = dto.Name;
            project.Description = dto.Description;
            return Task.FromResult<ProjectDto?>(ToDto(project));
        }

        public Task<ProjectDto?> GetByIdAsync(Guid id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id);
            if (project == null) return Task.FromResult<ProjectDto?>(null);
            return Task.FromResult<ProjectDto?>(ToDto(project));
        }

        public Task<List<ProjectDto>> GetAllAsync()
        {
            return Task.FromResult(_projects.Select(p => ToDto(p)).ToList());
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var project = _projects.FirstOrDefault(project => project.Id == id);
            if (project == null) return Task.FromResult(false);
            _projects.Remove(project);
            return Task.FromResult(true);
        }

        private static ProjectDto ToDto(Project project)
        {
            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                OwnerUserId = project.OwnerUserId
            };
        }
    }
}
