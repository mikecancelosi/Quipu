using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quipu.Core.DomainModel
{
    public class TeamMessage
    {
        [Key]
        public int ID { get; set; }        
        public string Subject { get; set; }
        [Required(ErrorMessage = "Each message needs to have contents")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Each message needs to be attached to a project")]
        public Project Project { get; set; }
        [Required(ErrorMessage = "Each message needs to have been created by a user")]
        public User Creator { get; set; }
    }
}
