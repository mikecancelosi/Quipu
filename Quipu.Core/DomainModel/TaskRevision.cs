using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quipu.Core.DomainModel
{
    /// <summary>
    /// Changes made to a task get saved in order to display on 
    /// the TaskDetail page.
    /// </summary>
    public class TaskRevision
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Task")]
        public int TaskID { get; set; }
        public DateTime Date { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public RevisionType RevisionType { get; set; }

        public virtual Task Task { get; set; }
    }

    /// <summary>
    /// Types of revisions made to a task that ought to be recorded.
    /// </summary>
    public enum RevisionType
    {
        Title, 
        Assignee,
        Date,
        Priority,
        Status,
        Description,
        Subtask,
    }
}
