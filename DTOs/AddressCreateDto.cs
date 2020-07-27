using System.ComponentModel.DataAnnotations;

namespace Contact.DTOs
{
    public class AddressCreateDto
    {
        [Required]
        [MaxLength(200)]
        public string StreetAddress { get; set; }

        [MaxLength(50)]
        public string Suite { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string State { get; set; }

        [MaxLength(10)]
        public string ZipCode { get; set; }
    }
}
