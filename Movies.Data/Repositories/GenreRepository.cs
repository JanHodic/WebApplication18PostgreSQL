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
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MoviesDbContext moviesDbContext) : base(moviesDbContext)
        {
        }

        public IList<Genre> FindAllByNames(IEnumerable<string> names)
        {
            return dbSet.Where(g => names.Contains(g.Name)).ToList();
        }
    }
}
