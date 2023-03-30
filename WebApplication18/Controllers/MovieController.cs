using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Interfaces;
using Movies.Api.Models;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;
        public MoviesController
            (
                IMovieService service,
                IMapper mapper
            )
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieDto movie)
        {
            MovieDto createdMovie = _service.AddMovie(movie);
            return StatusCode(StatusCodes.Status201Created, createdMovie);
        }
    }
}
