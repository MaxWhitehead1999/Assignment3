using System.ComponentModel.DataAnnotations;
using Assignment3.Interface;

namespace Assignment3.Models
{
    public class Patient : IDCreation, HasFullName
    {
        

        [Required]
        public DateTimeOffset DateOfBirth { get; set; }
         
    }
}
