using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models
{
    public abstract class IDCreation
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public DateTimeOffset CreationTime { get; set; }
    }
}
