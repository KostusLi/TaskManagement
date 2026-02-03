using TaskManager.DTOs.Projects;

namespace TaskManager.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDto> CreateAsync(CreateProjectDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<List<ProjectDto>> GetAllAsync();
        Task<ProjectDto?> GetByIdAsync(Guid id);
        Task<ProjectDto?> UpdateAsync(UpdateProjectDto dto, Guid id);
    }
}