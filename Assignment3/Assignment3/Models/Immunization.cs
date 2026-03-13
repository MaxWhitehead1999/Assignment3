using System.ComponentModel.DataAnnotations;


namespace Assignment3.Models
{
    public class Immunization : IDCreation
    {
        [Required]
        [MaxLength(128)]
        public string OfficialName { get; set; }

        [MaxLength(128)]
        public String TradeName { get; set; }

        [Required]
        [MaxLength(255)]
        public String LotNumber { get; set; }


        [Required]
        public DateTimeOffset ExpirationDate { get; set; }

        public DateTimeOffset UpdatedTime { get; set; }

    }
}
