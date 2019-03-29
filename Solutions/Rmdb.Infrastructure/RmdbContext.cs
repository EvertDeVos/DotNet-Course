using Microsoft.EntityFrameworkCore;
using Rmdb.Domain.Model;

namespace Rmdb.Infrastructure
{
    public class RmdbContext : DbContext
    {
        public RmdbContext(DbContextOptions<RmdbContext> options): base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
