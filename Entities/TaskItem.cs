using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum TaskStatus
    {
        New,
        InProgress,
        Done
    }

    public class TaskItem
    {
        private Guid Id {  get; set; }
        private string Title { get; set; }
        public string? Description { get; set; }
        private TaskStatus Status { get; set; }
        public DateTime? DueDate { get; set; }

        public Guid ProjectId { get; set; }
        public Guid AssignedUserId { get; set; }
    }
}
