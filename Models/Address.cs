using System.ComponentModel.DataAnnotations;

namespace Contact.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
