using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.Model
{
    public class Actor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? Deceased { get; set; }

        public ICollection<MovieActor> PlayedMovies { get; set; } = new List<MovieActor>();

        // Private empty constructor for EF
        private Actor() { }

        public Actor(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public int Age
        {
            get
            {
                if (!BirthDate.HasValue)
                {
                    return 0;
                }

                Deceased = Deceased ?? DateTime.Now;
                return (int)((Deceased.Value - BirthDate.Value).Days / 365.25m);
            }
        }
    }
}
