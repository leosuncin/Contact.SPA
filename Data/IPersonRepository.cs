using System.Collections.Generic;
using Contact.DTOs;
using Contact.Models;

namespace Contact.Data
{
    public interface IPersonRepository
    {
        Person CreatePerson(PersonCreateDto personCreate);
        Person GetPersonById(int id);
        IEnumerable<Person> GetAllPeople();
        Person UpdatePerson(Person person, PersonUpdateDto personUpdate);
        void DeletePerson(Person person);
    }
}
