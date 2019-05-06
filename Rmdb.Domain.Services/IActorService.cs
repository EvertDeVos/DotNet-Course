using System;
using Rmdb.Domain.Dtos.Actors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rmdb.Domain.Services
{
    public interface IActorService
    {
        Task<IEnumerable<ActorListDto>> GetAsync();
        Task<ActorDetailDto> GetAsync(Guid id);
        Task<Guid> AddAsync(AddActorDto addActor);
        Task<ActorDetailDto> UpdateAsync(Guid id, EditActorDto editActor);
        Task<bool> DeleteAsync(Guid id);
    }
}
