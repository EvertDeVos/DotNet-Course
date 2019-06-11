using System.ComponentModel.DataAnnotations;

namespace Rmdb.Domain.Dtos.Movies
{
    public class AddMovieDto
    {
        [Required, MinLength(1), MaxLength(100)]
        public string Title { get; set; }

        [MinLength(1), MaxLength(500)]
        public string Description { get; set; }
    }
}
