using Assignment3.Interface;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Assignment3.Models
{
    public class Provider : IDCreation, HasFullName, HasAddress
    {

        [Required]
        public IUnsignedNumber LicenseNumber { get; set; }
      

    }
}
