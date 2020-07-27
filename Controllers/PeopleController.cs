using Contact.DTOs;
using Contact.Data;
using Contact.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PeopleController(IPersonRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<Person> CreatePerson(PersonCreateDto personCreate)
        {
            var person = _repository.CreatePerson(personCreate);

            return CreatedAtRoute(nameof(GetPersonById), new { Id = person.Id }, person);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPeople()
        {
            var people = _repository.GetAllPeople();

            return Ok(people);
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        public ActionResult<Person> GetPersonById(int id)
        {
            var person = _repository.GetPersonById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPut("{id}")]
        public ActionResult<Person> UpdatePerson(int id, PersonUpdateDto personUpdate)
        {
            var person = _repository.GetPersonById(id);

            if (person == null) return NotFound();

            return Ok(_repository.UpdatePerson(person, personUpdate));
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            var person = _repository.GetPersonById(id);

            if (person == null) return NotFound();

            _repository.DeletePerson(person);

            return NoContent();
        }
    }
}
