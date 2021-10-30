
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quipu.Core.DomainModel
{
    public class Task
    {
        public Task()
        {
            Alerts = new HashSet<Alert>();
            Subtasks = new HashSet<Task>();
            Revisions = new HashSet<TaskRevision>();
        }

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="A task needs to have a title")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        [ForeignKey("Priority")]
        public int? PriorityID { get; set; }
        [ForeignKey("Status")]
        public int? StatusID { get; set; }
        [ForeignKey("AssignedToUser")]
        public int? AssignedToUserID { get; set; }
        [ForeignKey("StatusCategory")]
        public int? StatusCategoryID { get; set; }
        [ForeignKey("ParentTask")]
        public int? ParentTaskID { get; set; }
        [ForeignKey("DiscussionOwner")]
        public int? DiscussionOwnerID { get; set; }


        public virtual Project Project { get; set; }
        public virtual PriorityType Priority { get; set; }
        public virtual StatusType Status { get; set; }
        public virtual TaskStatusCategory StatusCategory { get; set; }
        public virtual User AssignedToUser { get; set; }
        public virtual ICollection<Alert> Alerts { get; set; }
        public virtual Task ParentTask { get; set; }
        public virtual ICollection<Task> Subtasks { get; set; }
        public virtual ICollection<TaskRevision> Revisions { get; set; }
        public virtual DiscussionOwner DiscussionOwner { get; set; }        
    }
}
