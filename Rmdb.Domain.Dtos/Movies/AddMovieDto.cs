using System.ComponentModel.DataAnnotations;

namespace Rmdb.Domain.Dtos.Movies
{
    public class AddMovieDto
    {
        [MinLength(1)]
        public string Title { get; set; }
    }
}
