using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quipu.Core.DomainModel
{
    public class Discussion
    {
        public Discussion()
        {
            
        }

        [Key]
        public int ID { get; set; }
        public string Message_Contents { get; set; }
        public int RecordID { get; set; }
        [ForeignKey("User")]
        public int? UserID { get; set; }
        public DateTime Date_Posted { get; set; }

        public virtual User User { get; set; }
    }
}
