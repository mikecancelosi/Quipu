using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quipu.Core.DomainModel
{
    public class Task
    {
        public Task()
        {
            Discussions = new HashSet<Discussion>();
            Alerts = new HashSet<Alert>();
        }

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="A task needs to have a title")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        [ForeignKey("Priority")]
        public int PriorityID { get; set; }
        [ForeignKey("Status")]
        public int StatusID { get; set; }
        [ForeignKey("AssignedToUser")]
        public int AssignedToUserID { get; set; }
        [ForeignKey("StatusCategory")]
        public int StatusCategoryID { get; set; }

        public virtual PriorityType Priority { get; set; }
        public virtual StatusType Status { get; set; }
        public virtual TaskStatusCategory StatusCategory { get; set; }
        public virtual User AssignedToUser { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<Alert> Alerts { get; set; }
    }
}
