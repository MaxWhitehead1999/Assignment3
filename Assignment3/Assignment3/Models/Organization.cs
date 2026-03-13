using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Assignment3.Interface;

namespace Assignment3.Models
{
    public class Organization : IDCreation, HasAddress
    {
        [Required]
        public String Name { get; set; }
        
        [Required]
        public String Type { get; set; }

    }
}
