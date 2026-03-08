using Entities;
using TaskManager.Data;
using TaskManager.DTOs.Projects;
using TaskManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto dto)
        {
            var project = new Project(Guid.NewGuid(), dto.Name, dto.Description, dto.OwnerUserId);
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return ToDto(project);
        }

        public async Task<ProjectDto?> UpdateAsync(UpdateProjectDto dto, Guid id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
                return null;

            project.Name = dto.Name;
            project.Description = dto.Description;

            await _context.SaveChangesAsync();

            return ToDto(project);
        }

        public async Task<ProjectDto?> GetByIdAsync(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return null;
            return ToDto(project);
        }

        public async Task<List<ProjectDto>> GetAllAsync()
        {
            var projects = await _context.Projects.ToListAsync();
            return projects.Select(ToDto).ToList();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var project =await  _context.Projects.FindAsync(id);
            if (project == null) return false;

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return true;
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
