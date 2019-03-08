using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Rmdb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.Data
{
    /* this repository is only for demo purposes */
    public class MovieRepository
    {

        private const string Key = "Movies";

        private readonly ISession _sessionStorage;
        private List<Movie> _movies;

        public MovieRepository(ISession session)
        {
            _sessionStorage = session;
            Init();
        }

        public IEnumerable<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }

        public Movie Get(Guid id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public void Create(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            _movies.Add(movie);
            Save();
        }

        public void Update(Guid id, Movie movie)
        {
            var oldVersion = _movies.First(m => m.Id == id);
            oldVersion.Title = movie.Title;
            oldVersion.Description = movie.Description;
            oldVersion.ReleaseDate = movie.ReleaseDate;
            oldVersion.RunTime = movie.RunTime;
            oldVersion.Score = movie.Score;
            Save();
        }

        public void Delete(Guid id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _movies.Remove(movie);
                Save();
            }
        }

        private void Init()
        {
            var content = _sessionStorage.GetString(Key);
            if (string.IsNullOrWhiteSpace(content))
            {
                _movies = new List<Movie> {
                    new Movie("The shawshank redemption")
                    { ReleaseDate = new DateTime(1994,3,2), Color = true, RunTime = new TimeSpan(2,22,0),
                        Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency." },
                    new Movie("The Godfather")
                    { ReleaseDate = new DateTime(1972, 9,27), Color = true, RunTime = new TimeSpan(2,55,0),
                        Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." },
                    new Movie("The Godfather: Part 2")
                    { ReleaseDate = new DateTime(1974,7,17), Color = true, RunTime = new TimeSpan(3,22,0),
                        Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate." },
                    new Movie("12 Angry Men")
                    { ReleaseDate = new DateTime(1957,4, 10), Color = false, RunTime = new TimeSpan(1,36,0),
                        Description = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence." }
                };
                Save();
                return;
            }

            _movies = JsonConvert.DeserializeObject<Movie[]>(content).ToList();
        }

        private void Save()
        {
            var content = JsonConvert.SerializeObject(_movies.ToArray());
            _sessionStorage.SetString(Key, content);
        }
    }
}
