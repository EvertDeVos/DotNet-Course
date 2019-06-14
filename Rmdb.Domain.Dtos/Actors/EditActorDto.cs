using System;
using System.ComponentModel.DataAnnotations;

namespace Rmdb.Domain.Dtos.Actors
{
    public class EditActorDto
    {
        [Required, MinLength(1), MaxLength(50)]
        public string Name { get; set; }

        [Required, MinLength(1), MaxLength(50)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? Deceased { get; set; }
    }
}
