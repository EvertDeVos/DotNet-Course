using AutoMapper;
using Rmdb.Web.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewModels.Actors
{
    public class ActorMapperProfile : Profile
    {
        public ActorMapperProfile()
        {
            CreateMap<ActorCreateViewModel, Actor>();
            CreateMap<ActorUpdateViewModel, Actor>();
            CreateMap<Actor, ActorViewModel>()
                .ForMember(dto => dto.FullName, options => options.MapFrom(model => $"{model.Name}, {model.LastName}"))
                .ForMember(dto => dto.Age, options => options.MapFrom(model => model.Age > 0 ? model.Age.ToString() : "Onbekend"));
            CreateMap<Actor, ActorDetailsViewModel>();
        }
    }
}
