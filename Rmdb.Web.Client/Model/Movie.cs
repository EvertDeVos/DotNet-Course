using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.Model
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public TimeSpan? RunTime { get; set; }

        public double Score { get; set; }
        public bool Color { get; set; }
        public virtual ICollection<MovieActor> Actors { get; set; } = new List<MovieActor>();

        // Private empty constructor for EF
        private Movie()
        {
        }

        public Movie(string title)
        {
            Title = title;
        }
    }
}
