using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rmdb.Domain.Model
{
    public class Movie
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
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
