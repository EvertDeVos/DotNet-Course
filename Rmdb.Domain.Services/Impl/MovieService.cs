using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Rmdb.Domain.Dtos.Movies;
using Rmdb.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Domain.Services.Impl
{
    public class MovieService : IMovieService
    {
        private readonly RmdbContext _ctx;

        public MovieService(RmdbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<MovieListDto>> GetMoviesAsync()
        {
            return await _ctx.Movies.ProjectTo<MovieListDto>().ToListAsync();
        }
    }
}
