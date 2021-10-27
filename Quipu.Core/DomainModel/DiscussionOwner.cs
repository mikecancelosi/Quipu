using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quipu.Core.DomainModel
{
    public class DiscussionOwner
    {
        public DiscussionOwner()
        {
            Discussions = new HashSet<Discussion>();
        }

        [Key]
        public int ID { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }
    }
}
