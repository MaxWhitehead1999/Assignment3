using System.ComponentModel.DataAnnotations;

namespace Assignment3.Interface
{
    public interface HasAddress
    {
        [Required]
        public string Address { get; set; }
    }
}
