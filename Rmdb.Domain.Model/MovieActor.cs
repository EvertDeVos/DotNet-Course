using System;

namespace Rmdb.Domain.Model
{
    public class MovieActor
    {
        // Private empty constructor for EF
        private MovieActor()
        {

        }

        public MovieActor(Guid movieId, Guid actorId)
        {
            MovieId = movieId;
            ActorId = actorId;
        }

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid ActorId { get; set; }
        public Person Actor { get; set; }
    }
}
