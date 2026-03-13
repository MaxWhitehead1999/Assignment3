using System.ComponentModel.DataAnnotations;

namespace Assignment3.Interface
{
    public interface HasFullName
    {

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

    }
}
