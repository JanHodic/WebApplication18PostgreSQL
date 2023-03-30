using System.Collections.Generic;

namespace Movies.Api.Interfaces
{
    public interface IGenreService
    {
        IList<string> GetAllGenres();
    }
}
