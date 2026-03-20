using Assignment3.Interface;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Assignment3.Models
{
    public class Provider : IDCreation, HasFullName, HasAddress
    {

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string LicenseNumber { get; set; }

        [MaxLength(128)]
        public string OrganizationName { get; set; }

        public DateTimeOffset UpdatedTime { get; set; }
    }
}
