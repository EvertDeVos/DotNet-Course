using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.Model
{
    public class MovieActor
    {
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
        public Actor Actor { get; set; }
    }
}
