using Rmdb.Domain.Dtos.Movies;
using System.Collections.Generic;

namespace Rmdb.Domain.Services
{
    public interface IMovieService
    {
        IEnumerable<MovieListDto> GetMovies();
    }
}
