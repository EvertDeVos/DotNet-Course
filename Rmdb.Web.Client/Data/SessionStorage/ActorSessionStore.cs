using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Rmdb.Domain.Model;
using Rmdb.Domain.Model.Extensions;
using Rmdb.Web.Client.Data.Contracts;
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
        private List<Person> _actors;



        public ActorSessionStore(IHttpContextAccessor contextAccessor)
        {
            _sessionStorage = contextAccessor.HttpContext.Session;
            Init();
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return _actors;
        }

        public async Task<Person> Get(Guid id)
        {
            return _actors.FirstOrDefault(p => p.Id == id);
        }

        public async Task Add(Person person)
        {
            person.Id = Guid.NewGuid();
            _actors.Add(person);
            Save();
        }
        public async Task<Person> Update(Guid id, Person actor)
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

        public async Task Delete(Guid id)
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
                _actors = new List<Person> {
                    new Person("Christopher", "Nolan") { Id=Guid.NewGuid(), BirthDate= new DateTime(1970,7,30)},
                    new Person("Steven", "Spielberg") { Id=Guid.NewGuid(), BirthDate= new DateTime(1948,12,18)},
                    new Person("Martin", "Scorsese") { Id=Guid.NewGuid(), BirthDate= new DateTime(1942,10,17)},
                    new Person("Alfred", "Hitchcock") { Id=Guid.NewGuid(), BirthDate= new DateTime(1899,8,13), Deceased = new DateTime(1980,4,29)},
                    new Person("Hayao", "Miyazaki") { Id=Guid.NewGuid(), BirthDate= new DateTime(1941,1,5)},
                };
                Save();
                return;
            }

            _actors = JsonConvert.DeserializeObject<Person[]>(content).ToList();
        }

        public async Task Save()
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
