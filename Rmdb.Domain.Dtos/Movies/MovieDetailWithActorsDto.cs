using Rmdb.Domain.Dtos.Actors;
using System;
using System.Collections.Generic;

namespace Rmdb.Domain.Dtos.Movies
{
    public class MovieDetailWithActorsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan RunTime { get; set; }
        public double Score { get; set; }
        public bool Color { get; set; }
        public IEnumerable<ActorListDto> Actors { get; set; }
    }
}
