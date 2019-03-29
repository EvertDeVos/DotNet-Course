using System;
using System.Collections.Generic;
using System.Text;
using Rmdb.Domain.Model;

namespace Rmdb.Domain.Services.Impl
{
    public class MovieService : IMovieService
    {
        public IEnumerable<Movie> GetMovies()
        {
            return new Movie[]
            {
                new Movie("Scarface"),
                new Movie("American Pie"),
                new Movie("FC De Kampioenen")
            };
        }
    }
}
