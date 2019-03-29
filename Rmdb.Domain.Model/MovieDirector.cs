using System;

namespace Rmdb.Domain.Model
{
    public class MovieDirector
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
