using System.ComponentModel.DataAnnotations;

namespace ef_core.Models
{
    public class Broker
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}