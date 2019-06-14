using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Rmdb.Domain.Dtos.Actors;
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
            return await _ctx.Movies
                .ProjectTo<MovieDetailDto>()
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<MovieDetailWithActorsDto> GetWithActorsAsync(Guid id)
        {
            return await _ctx.Movies
                .ProjectTo<MovieDetailWithActorsDto>()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Guid> AddAsync(AddMovieDto movie)
        {
            var newMovie = new Movie(movie.Title)
            {
                Description = movie.Description
            };

            await _ctx.Movies.AddAsync(newMovie);

            await _ctx.SaveChangesAsync();

            return newMovie.Id;
        }

        public async Task<MovieDetailDto> UpdateAsync(Guid id, EditMovieDto editMovie)
        {
            var movie = await _ctx.Movies.FindAsync(id);

            if (movie == null)
            {
                return null;
            }

            movie.Title = editMovie.Title;
            movie.Description = editMovie.Description;
            movie.ReleaseDate = editMovie.ReleaseDate;
            movie.RunTime = editMovie.RunTime;
            movie.Score = editMovie.Score;
            movie.Color = editMovie.Color;

            await _ctx.SaveChangesAsync();

            return Mapper.Map<MovieDetailDto>(movie);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var movie = await _ctx.Movies.FindAsync(id);

            if (movie == null)
            {
                return false;
            }

            _ctx.Movies.Remove(movie);

            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<ActorListDto> AddActorToMovieAsync(Guid movieId, AddActorToMovieDto addActor)
        {
            var movie = await _ctx.Movies.FindAsync(movieId);
            var actor = await _ctx.Actors.FindAsync(addActor.ActorId);

            if (movie == null || actor == null)
            {
                return null;
            }

            movie.Actors.Add(new MovieActor(movieId, addActor.ActorId));

            await _ctx.SaveChangesAsync();

            return Mapper.Map<ActorListDto>(actor);
        }

    }
}
