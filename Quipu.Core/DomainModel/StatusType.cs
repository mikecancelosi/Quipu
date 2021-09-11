using System.ComponentModel.DataAnnotations;

namespace Quipu.Core.DomainModel
{
    public class StatusType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
