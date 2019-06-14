using AutoMapper;
using Rmdb.Domain.Dtos.Movies;
using Rmdb.Domain.Model;
using System.Linq;

namespace Rmdb.Domain.Services.Profiles
{
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDetailDto>();

            CreateMap<Movie, MovieDetailWithActorsDto>()
                .ForMember(dto => dto.Actors, opt => opt.MapFrom(movie => movie.Actors.Select(x => x.Actor)));
        }
    }
}
