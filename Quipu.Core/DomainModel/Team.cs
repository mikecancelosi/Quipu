using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quipu.Core.DomainModel
{
    public class Team
    {
        public Team()
        {           
            this.Members = new HashSet<User>();
            this.Messages = new HashSet<TeamMessage>();
        }

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Each team needs to have a name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Members { get; set; }
        [NotMapped]
        public virtual ICollection<Project> Projects
        {
            get
            {
                var projects = new HashSet<Project>();
                var source = Members.Select(u => u.Projects);
                foreach (var projectCollection in source)
                {
                    projects.Union(projectCollection);
                }

                return projects;
            }
        }
        public virtual ICollection<TeamMessage> Messages { get; set; }
    }
}
