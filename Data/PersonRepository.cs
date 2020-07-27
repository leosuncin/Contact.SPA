using AutoMapper;
using Contact.DTOs;
using Contact.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Contact.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ContactContext _context;
        private readonly IMapper _mapper;

        public PersonRepository(ContactContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public Person CreatePerson(PersonCreateDto personCreate)
        {
            if (personCreate == null) throw new ArgumentNullException(nameof(personCreate));

            var person = _mapper.Map<Person>(personCreate);

            _context.People.Add(person);
            _context.SaveChanges();

            return person;
        }

        public void DeletePerson(Person person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            _context.People.Remove(person);
            _context.SaveChanges();
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _context.People.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _context.People
                .Include(person => person.Addresses)
                .Include(person => person.EmailAddresses)
                .Include(person => person.PhoneNumbers)
                .FirstOrDefault(person => person.Id == id);
        }

        public Person UpdatePerson(Person person, PersonUpdateDto personUpdate)
        {
            if (person == null || personUpdate == null) throw new ArgumentNullException(nameof(person));

            _mapper.Map(personUpdate, person);
            _context.SaveChanges();

            return person;
        }
    }
}
