using Microsoft.AspNetCore.Mvc.Rendering;
using Rmdb.Web.Client.ViewModels.Actors;
using Rmdb.Web.Client.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewModels.Movies
{
    public class MovieDetailsViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Titel")]
        public string Title { get; set; }
        [DisplayName("Beschrijving")]
        public string Description { get; set; }

        [DisplayName("Premiere")]
        public DateViewModel ReleaseDate { get; set; }

        [DisplayName("Duur")]
        public TimeSpan? RunTime { get; set; }

        [DisplayName("Score")]
        public double? Score { get; set; }
        [DisplayName("Kleuren")]
        public bool Color { get; set; }

        [DisplayName("Acteurs")]
        public IEnumerable<ActorViewModel> Actors { get; set; }

        public IEnumerable<ActorViewModel> AllActors { get; set; }

        public Guid Selected { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}
