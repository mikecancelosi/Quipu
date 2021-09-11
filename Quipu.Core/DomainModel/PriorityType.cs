using System.ComponentModel.DataAnnotations;

namespace Quipu.Core.DomainModel
{
    public class PriorityType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
