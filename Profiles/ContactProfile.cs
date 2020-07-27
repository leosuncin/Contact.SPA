using AutoMapper;
using Contact.DTOs;
using Contact.Models;

namespace Contact.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<PhoneCreateDto, Phone>();
            CreateMap<EmailCreateDto, Email>();
            CreateMap<AddressCreateDto, Address>();
            CreateMap<PersonCreateDto, Person>();
            CreateMap<PersonUpdateDto, Person>();
            CreateMap<Person, PersonUpdateDto>();
        }
    }
}
