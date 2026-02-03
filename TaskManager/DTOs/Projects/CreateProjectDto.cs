using System.ComponentModel.DataAnnotations;

namespace TaskManager.DTOs.Projects
{
    public class CreateProjectDto
    {
        [Required]
        [StringLength(40, MinimumLength = 4)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public Guid OwnerUserId { get; set; }
    }
}
