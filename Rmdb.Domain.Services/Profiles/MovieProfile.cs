using AutoMapper;
using Rmdb.Domain.Dtos.Movies;
using Rmdb.Domain.Model;

namespace Rmdb.Domain.Services.Profiles
{
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDetailDto>();
        }
    }
}
