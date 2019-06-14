using Rmdb.Domain.Dtos.Actors;
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
        Task<MovieDetailWithActorsDto> GetWithActorsAsync(Guid id);
        Task<Guid> AddAsync(AddMovieDto movie);
        Task<MovieDetailDto> UpdateAsync(Guid id, EditMovieDto editMovie);
        Task<bool> DeleteAsync(Guid id);
        Task<ActorListDto> AddActorToMovieAsync(Guid movieId, AddActorToMovieDto addActor);
    }
}
