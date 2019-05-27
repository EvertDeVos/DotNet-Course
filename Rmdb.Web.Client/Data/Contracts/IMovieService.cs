using Rmdb.Web.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.Data.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllAsync();

        Task<Movie> GetAsync(Guid id);

        Task<Movie> CreateAsync(Movie movie);

        Task<Movie> UpdateAsync(Guid id, Movie movie);

        Task<MovieActor> AddActorAsync(Guid movieId, Guid actorId);

        Task DeleteAsync(Guid id);

        void Save();
    }
}
