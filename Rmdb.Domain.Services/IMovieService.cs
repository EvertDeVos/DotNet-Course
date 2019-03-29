using Rmdb.Domain.Dtos.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmdb.Domain.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieListDto>> GetMoviesAsync();
    }
}
