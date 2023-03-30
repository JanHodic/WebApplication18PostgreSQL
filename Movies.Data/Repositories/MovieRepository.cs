using Movies.Data.Data;
using Movies.Data.Interfaces;
using Movies.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MoviesDbContext moviesDbContext) : base(moviesDbContext)
        {
        }
    }
}
