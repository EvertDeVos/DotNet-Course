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
            modelBuilder.Entity<MovieActor>()
                .ToTable("MovieActor")
                .HasKey(mp => new { mp.MovieId, mp.ActorId });

            modelBuilder.Entity<MovieActor>()
                .HasOne(mp => mp.Movie)
                .WithMany(m => m.Actors)
                .HasForeignKey(mp => mp.ActorId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(mp => mp.Actor)
                .WithMany(m => m.PlayedMovies)
                .HasForeignKey(mp => mp.ActorId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> Actors { get; set; }
    }
}
