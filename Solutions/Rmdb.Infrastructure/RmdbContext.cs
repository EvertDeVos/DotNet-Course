using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Rmdb.Domain.Model;

namespace Rmdb.Infrastructure
{
    public class RmdbContext : DbContext
    {
        public RmdbContext(DbContextOptions<RmdbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviePerson>()
                .ToTable("MovieActors")
                .HasKey(mp => new { mp.MovieId, mp.PersonId });

            modelBuilder.Entity<MoviePerson>()
                .HasOne(mp => mp.Movie)
                .WithMany(m => m.Actors)
                .HasForeignKey(mp => mp.PersonId);

            modelBuilder.Entity<MoviePerson>()
                .HasOne(mp => mp.Person)
                .WithMany(m => m.PlayedMovies)
                .HasForeignKey(mp => mp.PersonId);


            modelBuilder.Entity<MovieDirector>()
                .ToTable("MovieDirectors")
                .HasKey(mp => new { mp.MovieId, mp.PersonId });

            modelBuilder.Entity<MovieDirector>()
                .HasOne(mp => mp.Movie)
                .WithMany(m => m.Directors)
                .HasForeignKey(mp => mp.PersonId);

            modelBuilder.Entity<MovieDirector>()
                .HasOne(mp => mp.Person)
                .WithMany(m => m.DirectedMovies)
                .HasForeignKey(mp => mp.PersonId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
