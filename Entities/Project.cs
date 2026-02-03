using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Project
    {
        private Guid Id {  get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        private Guid OwnerUserId { get; set; }

        public Project(Guid id, string name, string description, Guid owner)
        {
            Id = id;
            Name = name;
            Description = description;
            OwnerUserId = owner;
        }
    }
}
