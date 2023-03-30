using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Interfaces;
using Movies.Api.Models;
using Movies.Data.Enums;
using System.Collections;
using System.Collections.Generic;

namespace Movies.Api.Controllers
{
    namespace Movies.Api.Controllers
    {
        [Route("people")]
        [ApiController]
        public class PeopleController : ControllerBase
        {
            private readonly IPersonService personManager;

            public PeopleController(IPersonService personManager)
            {
                this.personManager = personManager;
            }

            [HttpGet]
            public IEnumerable<PersonDto> GetPeople()
            {
                return personManager.GetAllPeople();
            }

            [HttpGet("{id}")]
            public IActionResult GetPerson(int id)
            {
                var person = personManager.GetPerson(id);
                if(person == null)
                    return StatusCode(StatusCodes.Status404NotFound);

                return StatusCode(StatusCodes.Status200OK, person);
            }

            [HttpPost]
            public IActionResult AddPerson([FromBody] PersonDto person)
            {
                var createdPerson = personManager.AddPerson(person);
                var p = GetPerson(createdPerson.Id);
                if(p == null) return StatusCode(StatusCodes.Status406NotAcceptable);
                return StatusCode(StatusCodes.Status201Created, p);
                //return CreatedAtAction(nameof(GetPerson), new { personId = createdPerson.Id }, createdPerson);
            }

            [HttpPut("{id}")]
            public IActionResult EditPerson(int id, [FromBody] PersonDto person)
            {
                var updatedPerson = personManager.UpdatePerson(id, person);

                if (updatedPerson is null)
                    return NotFound();

                return Ok(updatedPerson);
            }

            [HttpDelete("{id}")]
            public IActionResult DeletePerson(int id)
            {
                bool result = personManager.DeletePerson(id);

                return result ? Ok() : NotFound();
            }

            [HttpGet("actors")]
            public IEnumerable<PersonDto> GetActors(int limit = int.MaxValue)
            {
                return personManager.GetAllPeople(PersonRoleEnum.Actor, 0, limit);
            }

            [HttpGet("directors")]
            public IEnumerable<PersonDto> GetDirectors(int limit = int.MaxValue)
            {
                return personManager.GetAllPeople(PersonRoleEnum.Director, 0, limit);
            }
        }
    }
}
