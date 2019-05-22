using AutoMapper;
using Rmdb.Web.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewModels.Movies
{
    public class MovieMapperProfile : Profile
    {
        public MovieMapperProfile()
        {
            CreateMap<MovieCreateViewModel, Movie>();
            CreateMap<MovieUpdateViewModel, Movie>();
            CreateMap<Movie, MovieViewModel>();
            CreateMap<Movie, MovieDetailsViewModel>();
            CreateMap<Movie, MovieUpdateViewModel>()
                .ForMember(vm => vm.ReleaseDate, options => options.MapFrom(model => model.ReleaseDate.HasValue ? model.ReleaseDate : DateTime.Now));

        }
    }
}
