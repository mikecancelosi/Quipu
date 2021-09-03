using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quipu.Core.DomainModel
{
    public class Team
    {
        public Team()
        {           
            this.Users = new HashSet<User>();
            this.Projects = new HashSet<Project>();
        }

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Each team needs to have a name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<TeamMessage> Messages { get; set; }
    }
}
