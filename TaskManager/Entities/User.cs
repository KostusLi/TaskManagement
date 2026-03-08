
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public User() { }
        public User (Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public List<Project> OwnedProjects { get; set; } = new();

        public List<TaskItem> AssignedTasks { get; set; } = new();

    }
}
