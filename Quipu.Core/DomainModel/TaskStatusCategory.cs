using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quipu.Core.DomainModel
{
    /// <summary>
    /// Groups tasks by what the status of the task is
    /// e.g: 'To do', 'In work', 'Done'
    /// </summary>
    public class TaskStatusCategory
    {
        public TaskStatusCategory()
        {           
            Tasks = new HashSet<Task>();
        }

        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "A task group needs to have a title")]
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
