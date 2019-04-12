using System;

namespace Rmdb.Domain.Model
{
    public class MovieActor
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid ActorId { get; set; }
        public Person Actor { get; set; }
    }
}
