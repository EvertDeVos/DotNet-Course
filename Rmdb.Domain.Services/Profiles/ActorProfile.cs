using AutoMapper;
using Rmdb.Domain.Dtos.Actors;
using Rmdb.Domain.Model;

namespace Rmdb.Domain.Services.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Person, ActorListDto>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(y => $"{y.Name} {y.LastName}"));

            CreateMap<Person, ActorDetailDto>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(y => $"{y.Name} {y.LastName}"));
        }
    }
}
