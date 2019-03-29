using System;

namespace Rmdb.Domain.Dtos.Movies
{
    public class MovieListDto
    {
        public MovieListDto(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
