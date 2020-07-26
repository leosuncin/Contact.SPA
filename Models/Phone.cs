using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contact.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(12)]
        [Column(TypeName = "varchar(12)")]
        public string PhoneNumber { get; set; }
    }
}
