using AutoMapper;
using Movies.Api.Interfaces;
using Movies.Data.Interfaces;
using Movies.Data.Models;
using System.Collections.Generic;

namespace Movies.Api.Models
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movies;
        private readonly IGenreRepository _genres;
        private readonly IPersonRepository _persons;
        private readonly IMapper _mapper;

        public MovieService
            (
            IMovieRepository movies,
            IGenreRepository genres,
            IPersonRepository persons,
            IMapper mapper
            )
        {
            _movies = movies;
            _genres = genres;
            _persons = persons;
            _mapper = mapper;
        }
        public MovieDto AddMovie(MovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);

            movie.Actors.AddRange(_persons.FindAllByIds(movieDto.Actors));
            movie.Genres.AddRange(_genres.FindAllByNames(movieDto.Genres));

            Movie addedMovie = _movies.Insert(movie);
            return _mapper.Map<MovieDto>(addedMovie);
        }

        public MovieDto DeleteMovie(MovieDto movie)
        {
            throw new System.NotImplementedException();
        }

        public MovieDto GetMovieById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MovieDto> GetMovies()
        {
            throw new System.NotImplementedException();
        }

        public MovieDto UpdateMovie(MovieDto movie)
        {
            throw new System.NotImplementedException();
        }
    }
}
