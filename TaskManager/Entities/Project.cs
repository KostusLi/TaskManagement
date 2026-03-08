//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Entities
//{
//    public class Project
//    {
//        public Guid Id {  get; set; }
//        [Required]
//        public string Name { get; set; }
//        public string? Description { get; set; }
//        [Required]
//        public Guid OwnerUserId { get; set; }

//        public Project() { }

//        public Project(Guid id, string name, string? description, Guid owner)
//        {
//            Id = id;
//            Name = name;
//            Description = description;
//            OwnerUserId = owner;
//        }
//    }
//}

using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Project
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public Guid OwnerUserId { get; set; }

        public User OwnerUser { get; set; }

        public List<TaskItem> Tasks { get; set; } = new();

        public Project() { }

        public Project(Guid id, string name, string? description, Guid owner)
        {
            Id = id;
            Name = name;
            Description = description;
            OwnerUserId = owner;
        }
    }
}