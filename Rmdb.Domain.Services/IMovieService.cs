using Rmdb.Domain.Dtos.Movies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmdb.Domain.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieListDto>> GetAsync();
        Task<MovieDetailDto> GetAsync(Guid id);
        Task<Guid> AddAsync(AddMovieDto movie);
    }
}
