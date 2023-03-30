using AutoMapper;
using Movies.Api.Interfaces;
using Movies.Data.Interfaces;
using System.Collections.Generic;

namespace Movies.Api.Models
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository repository;
        private readonly IMapper mapper;

        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public IList<string> GetAllGenres()
        {
            return mapper.Map<IList<string>>(repository.GetAll());
        }
    }
}
