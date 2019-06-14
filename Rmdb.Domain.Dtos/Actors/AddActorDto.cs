using System.ComponentModel.DataAnnotations;

namespace Rmdb.Domain.Dtos.Actors
{
    public class AddActorDto
    {
        [Required, MinLength(1), MaxLength(50)]
        public string Name { get; set; }

        [Required, MinLength(1), MaxLength(50)]
        public string LastName { get; set; }
    }
}
