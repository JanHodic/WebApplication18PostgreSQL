using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Interfaces;
using System.Collections;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService service;

        public GenresController(IGenreService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable GetGenres()
        {
            return service.GetAllGenres();
        }
    }
}
