using System;
using System.Collections.Generic;
using System.Text;

namespace Rmdb.Domain.Model
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

        public virtual List<Person> Directors { get; set; }
        public virtual List<Person> Actors { get; set; }

        // entity framework constructor
        private Movie()
        {

        }

        public Movie(string title)
        {
            Title = title;
        }
    }
}
