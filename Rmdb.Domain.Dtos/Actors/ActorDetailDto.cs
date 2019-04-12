using System;

namespace Rmdb.Domain.Dtos.Actors
{
    public class ActorDetailDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? Deceased { get; set; }
    }
}
