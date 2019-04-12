using System;
using System.ComponentModel.DataAnnotations;

namespace Rmdb.Domain.Dtos.Movies
{
    public class EditMovieDto
    {
        [Required, MinLength(1)]
        public string Title { get; set; }

        [Required, MinLength(1)]
        public string Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public TimeSpan RunTime { get; set; }

        [Required, Range(0, 10)]
        public double Score { get; set; }

        [Required]
        public bool Color { get; set; }
    }
}
