using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quipu.Core.DomainModel
{
    public class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
            Members = new HashSet<User>();
        }

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "A project needs to have a title")]
        public string Name { get; set; }
        public string Description { get; set; }        
        public PriorityType Priority { get; set; } 
        public StatusType Status { get; set; }
       
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<User> Members { get; set; }
        [NotMapped]
        public virtual ICollection<Team> Teams
        {
            get
            {
                var teams = new HashSet<Team>();
                var source = Members.Select(u => u.Teams);
                foreach (var teamCollection in source)
                {
                    teams.Union(teamCollection);
                }

                return teams;
            }
        }
    }
}
