using System;
using System.ComponentModel.DataAnnotations;

namespace Contact.DTOs
{
    public class PersonUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Range(13, Int32.MaxValue)]
        public int Age { get; set; }
    }
}
