using System.ComponentModel.DataAnnotations;

namespace Contact.DTOs
{
    public class PhoneCreateDto
    {
        [Required]
        [MaxLength(12)]
        public string PhoneNumber { get; set; }
    }
}
