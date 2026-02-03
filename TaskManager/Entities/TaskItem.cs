using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TaskItem
    {
        public Guid Id {  get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime? DueDate { get; set; }

        public Guid ProjectId { get; set; }
        public Guid AssignedUserId { get; set; }

        public TaskItem(Guid id, string title, string? description, TaskStatus status, DateTime? dueDate, Guid projectId, Guid assignedUserId)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
            DueDate = dueDate;
            ProjectId = projectId;
            AssignedUserId = assignedUserId;
        }
    }
}
