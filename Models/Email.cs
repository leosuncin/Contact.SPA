using System.ComponentModel.DataAnnotations;

namespace Contact.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
