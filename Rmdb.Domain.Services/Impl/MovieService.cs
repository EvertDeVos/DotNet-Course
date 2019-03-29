using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Rmdb.Domain.Dtos.Movies;
using Rmdb.Domain.Model;
using Rmdb.Infrastructure;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<MovieListDto>> GetAsync()
        {
            return await _ctx.Movies.ProjectTo<MovieListDto>().ToListAsync();
        }

        public async Task<MovieDetailDto> GetAsync(Guid id)
        {
            return await _ctx.Movies.ProjectTo<MovieDetailDto>().SingleAsync(x => x.Id == id);
        }

        public async Task<Guid> AddAsync(AddMovieDto movie)
        {
            var newMovie = new Movie(movie.Title);

            await _ctx.Movies.AddAsync(newMovie);

            await _ctx.SaveChangesAsync();

            return newMovie.Id;
        }
    }
}
