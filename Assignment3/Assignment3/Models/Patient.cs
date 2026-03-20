using System.ComponentModel.DataAnnotations;
using Assignment3.Interface;

namespace Assignment3.Models
{
    public class Patient : IDCreation, HasFullName
    {


        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [Required]
        public DateTimeOffset DateOfBirth { get; set; }

        public DateTimeOffset UpdatedTime { get; set; }

    }
}
