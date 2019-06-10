using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Rmdb.Web.Client.Data.Contracts;
using Rmdb.Web.Client.Model;
using Rmdb.Web.Client.ViewModels.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.Data.SessionStorage
{
    /* this repository is only for demo purposes */
    public class ActorSessionStore : IActorService
    {
        private const string Key = "Actors";

        private readonly ISession _sessionStorage;
        private List<Actor> _actors;

        public ActorSessionStore(IHttpContextAccessor contextAccessor)
        {
            _sessionStorage = contextAccessor.HttpContext.Session;
            Init();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            return _actors;
        }

        public async Task<Actor> GetAsync(Guid id)
        {
            return _actors.FirstOrDefault(p => p.Id == id);
        }

        public async Task AddAsync(Actor person)
        {
            person.Id = Guid.NewGuid();
            _actors.Add(person);
            Save();
        }

        public async Task<Actor> UpdateAsync(Guid id, Actor actor)
        {
            var oldVersion = _actors.First(p => p.Id == id);
            oldVersion.Name = actor.Name;
            oldVersion.LastName = actor.LastName;
            oldVersion.BirthDate = actor.BirthDate;
            oldVersion.Deceased = actor.Deceased;
            oldVersion.PlayedMovies = actor.PlayedMovies;

            Save();

            return oldVersion;
        }

        public async Task DeleteAsync(Guid id)
        {
            var actor = _actors.FirstOrDefault(p => p.Id == id);
            if (actor != null)
            {
                _actors.Remove(actor);
                Save();
            }
        }

        private void Init()
        {

            var content = _sessionStorage.GetString(Key);
            if (string.IsNullOrEmpty(content))
            {
                _actors = new List<Actor> {
                    new Actor("Tim", "Robins") { Id=Guid.NewGuid(), BirthDate= new DateTime(1958,8,16)},
                    new Actor("Morgan", "Freeman") { Id=Guid.NewGuid(), BirthDate= new DateTime(1937,6,1)},
                    new Actor("Alfredo", "Pacino") { Id=Guid.NewGuid(), BirthDate= new DateTime(1940,4,25)},
                    new Actor("Marlon", "Brando") { Id=Guid.NewGuid(), BirthDate= new DateTime(1924,4,3), Deceased = new DateTime(2004,7,1)},
                    new Actor("Henry", "Fonda") { Id=Guid.NewGuid(), BirthDate= new DateTime(1905,5,16), Deceased = new DateTime(1982,8,12)},
                };
                Save();
                return;
            }

            _actors = JsonConvert.DeserializeObject<Actor[]>(content).ToList();
        }

        public void Save()
        {
            // decouple movieActors
            var actors = _actors.Select(a =>
            {
                a.PlayedMovies = a.PlayedMovies
                    .Select(ma => new MovieActor(ma.MovieId, ma.ActorId))
                    .ToList();

                return a;
            });

            var content = JsonConvert.SerializeObject(actors);
            _sessionStorage.SetString(Key, content);
        }
    }
}
