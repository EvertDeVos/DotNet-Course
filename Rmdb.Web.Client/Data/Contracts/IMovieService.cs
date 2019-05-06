using Rmdb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.Data.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAll();

        Task<Movie> Get(Guid id);

        Task<Movie> Create(Movie movie);

        Task<Movie> Update(Guid id, Movie movie);

        Task<MovieActor> AddActor(Guid movieId, Guid actorId);

        Task Delete(Guid id);

        Task Save();
    }
}
