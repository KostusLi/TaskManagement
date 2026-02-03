using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Project
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid OwnerUserId { get; set; }

        public Project(Guid id, string name, string? description, Guid owner)
        {
            Id = id;
            Name = name;
            Description = description;
            OwnerUserId = owner;
        }
    }
}
