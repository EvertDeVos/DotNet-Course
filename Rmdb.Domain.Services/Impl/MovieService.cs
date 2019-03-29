using Rmdb.Domain.Dtos.Movies;
using System;
using System.Collections.Generic;

namespace Rmdb.Domain.Services.Impl
{
    public class MovieService : IMovieService
    {
        public MovieService()
        {

        }

        public IEnumerable<MovieListDto> GetMovies()
        {
            return new MovieListDto[]
            {
                new MovieListDto(Guid.NewGuid(), "FC De Kampioenen"),
                new MovieListDto(Guid.NewGuid(), "Scarface")
            };
        }
    }
}
