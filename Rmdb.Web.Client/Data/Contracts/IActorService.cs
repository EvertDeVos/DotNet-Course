using Rmdb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.Data.Contracts
{
    public interface IActorService
    {

        Task<IEnumerable<Person>> GetAll();

        Task<Person> Get(Guid id);

        Task Add(Person person);

        Task<Person> Update(Guid id, Person actor);

        Task Delete(Guid id);

        Task Save();
    }
}
