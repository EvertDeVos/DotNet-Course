using System;

namespace Rmdb.Domain.Dtos.Movies
{
    public class MovieDetailDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
