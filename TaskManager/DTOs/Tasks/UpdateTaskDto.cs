using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TaskManager.Enums;

namespace TaskManager.DTOs.Tasks
{
    public class UpdateTaskDto
    {
        [Required]
        [StringLength(40, MinimumLength = 4)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [EnumDataType(typeof(TasksStatus))]
        public TaskStatus Status { get; set; }
        public DateTime? DueDate { get; set; }

        [Required]
        public Guid AssignedUserId { get; set; }
    }
}
