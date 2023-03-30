using Movies.Api.Models;
using System.Collections.Generic;

namespace Movies.Api.Interfaces
{
    public interface IMovieService
    {
        MovieDto AddMovie(MovieDto movie);
        MovieDto GetMovieById(int id);
        IEnumerable<MovieDto> GetMovies();
        MovieDto UpdateMovie(MovieDto movie);
        MovieDto DeleteMovie(MovieDto movie);

    }
}
