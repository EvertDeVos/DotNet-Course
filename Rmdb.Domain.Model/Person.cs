using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rmdb.Domain.Model
{
    public class Person
    {
        public Guid Id { get; set; }

        [MaxLength(51)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? Deceased { get; set; }

        public ICollection<MovieActor> PlayedMovies { get; set; } = new List<MovieActor>();

        // Private empty constructor for EF
        private Person() { }

        public Person(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
    }
}
