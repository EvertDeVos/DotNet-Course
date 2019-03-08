using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Rmdb.Domain.Model;
using Rmdb.Domain.Model.Extensions;
using Rmdb.Web.Client.ViewModels.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.Data
{
    /* this repository is only for demo purposes */
    public class DirectorRepository
    {
        private const string Key = "Directors";

        private readonly ISession _sessionStorage;
        private List<Person> _directors;

        public IEnumerable<Person> Directors
        {
            get
            {
                return _directors;
            }
        }

        public DirectorRepository(ISession sessionStorage)
        {
            _sessionStorage = sessionStorage;
            Load();
        }

        public Person Get(Guid id)
        {
            return _directors.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Person vm)
        {
            var director = new Person(vm.Name, vm.LastName) { Id = Guid.NewGuid(), BirthDate = vm.BirthDate, Deceased = vm.Deceased };
            _directors.Add(director);
            Save();
        }
        public void Update(Guid id, Person vm)
        {
            var director = _directors.First(p => p.Id == id);
            director.Name = vm.Name;
            director.LastName = vm.LastName;
            director.BirthDate = vm.BirthDate;
            director.Deceased = vm.Deceased;

            Save();
        }

        public void Delete(Guid id)
        {
            var director = _directors.FirstOrDefault(p => p.Id == id);
            if (director != null)
            {
                _directors.Remove(director);
                Save();
            }
        }

        private void Init()
        {
            _directors = new List<Person> {
                new Person("Christopher", "Nolan") { Id=Guid.NewGuid(), BirthDate= new DateTime(1970,7,30)},
                new Person("Steven", "Spielberg") { Id=Guid.NewGuid(), BirthDate= new DateTime(1948,12,18)},
                new Person("Martin", "Scorsese") { Id=Guid.NewGuid(), BirthDate= new DateTime(1942,10,17)},
                new Person("Alfred", "Hitchcock") { Id=Guid.NewGuid(), BirthDate= new DateTime(1899,8,13), Deceased = new DateTime(1980,4,29)},
                new Person("Hayao", "Miyazaki") { Id=Guid.NewGuid(), BirthDate= new DateTime(1941,1,5)},
            };

            Save();
        }
        private void Load()
        {
            var content = _sessionStorage.GetString(Key);
            if (string.IsNullOrEmpty(content))
            {
                Init();
                return;
            }

            _directors = JsonConvert.DeserializeObject<Person[]>(content).ToList();
        }
        private void Save()
        {
            var content = JsonConvert.SerializeObject(_directors.ToArray());
            _sessionStorage.SetString(Key, content);
        }
    }
}
