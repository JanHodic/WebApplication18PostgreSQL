using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Interfaces;
using Movies.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Api.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService manager;

        public CarController(ICarService manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public IEnumerable<CarDto> GetPeople()
        {
            return manager.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = manager.Get(id);
            if (item == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return StatusCode(StatusCodes.Status200OK, item);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CarDto item)
        {
            var created = manager.Add(item);
            var p = Get(created.Id);
            if (p == null) return StatusCode(StatusCodes.Status406NotAcceptable);
            return StatusCode(StatusCodes.Status201Created, p);
            //return CreatedAtAction(nameof(GetPerson), new { personId = createdPerson.Id }, createdPerson);
        }

        [HttpPost("{companyName},{carName}")]
        public Task<bool> CheckAuto(string companyName, string carName)
        {
            return manager.CheckAuto(companyName, carName);
        }

        [HttpPost("{companyName},{name}, {notMeaningfulVariable}")]
        public Task<bool> CheckAutoWithoutCollation(string companyName, string name, string notMeaningfulVariable)
        {
            return manager.CheckAutoWithoutCollation(companyName, name, notMeaningfulVariable);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] CarDto item)
        {
            var updated = manager.Update(id, item);

            if (updated is null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = manager.Delete(id);

            return result ? Ok() : NotFound();
        }
    }
}
