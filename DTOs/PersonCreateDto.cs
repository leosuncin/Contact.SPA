using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contact.DTOs
{
    public class PersonCreateDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Range(13, Int32.MaxValue)]
        public int Age { get; set; }
        public List<AddressCreateDto> Addresses { get; set; } = new List<AddressCreateDto>();
        public List<EmailCreateDto> EmailAddresses { get; set; } = new List<EmailCreateDto>();
        public List<PhoneCreateDto> PhoneNumbers { get; set; } = new List<PhoneCreateDto>();
    }
}
