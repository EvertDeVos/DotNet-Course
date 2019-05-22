using Rmdb.Web.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.Data.Contracts
{
    public interface IActorService
    {

        Task<IEnumerable<Actor>> GetAllAsync();

        Task<Actor> GetAsync(Guid id);

        Task AddAsync(Actor person);

        Task<Actor> UpdateAsync(Guid id, Actor actor);

        Task DeleteAsync(Guid id);

        void Save();
    }
}
