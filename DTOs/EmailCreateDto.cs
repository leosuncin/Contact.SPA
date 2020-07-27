using System.ComponentModel.DataAnnotations;

namespace Contact.DTOs
{
    public class EmailCreateDto
    {
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
    }
}
