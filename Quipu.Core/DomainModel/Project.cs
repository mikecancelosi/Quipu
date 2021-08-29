using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quipu.Core.DomainModel
{
    public enum PriorityValues
    {
        High,
        Medium,
        Low
    }

    public enum StatusValues
    {
        OnTrack,
        Blocked,
        AtRisk,
        OffTrack
    }

    public class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "A project needs to have a title")]
        public string Name { get; set; }
        public string Description { get; set; }        
        public PriorityValues Priority { get; set; } 
        public StatusValues Status { get; set; }
       
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
