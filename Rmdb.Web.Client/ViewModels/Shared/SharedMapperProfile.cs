using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewModels.Shared
{
    public class SharedMapperProfile : Profile
    {
        public SharedMapperProfile()
        {
            CreateMap<DateViewModel, DateTime>()
                .ConvertUsing(vm => new DateTime(vm.Year, vm.Month, vm.Day));
            CreateMap<DateTime, DateViewModel>()
                .ForMember(vm => vm.Day, options => options.MapFrom(vm => vm.Day))
                .ForMember(vm => vm.Month, options => options.MapFrom(vm => vm.Month))
                .ForMember(vm => vm.Year, options => options.MapFrom(vm => vm.Year));
        }
    }
}
