using Rmdb.Domain.Model;
using System.Collections.Generic;

namespace Rmdb.Domain.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();
    }
}
