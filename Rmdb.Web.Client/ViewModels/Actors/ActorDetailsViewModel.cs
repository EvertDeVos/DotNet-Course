using Microsoft.AspNetCore.Mvc.Rendering;
using Rmdb.Web.Client.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewModels.Actors
{
    public class ActorDetailsViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Voornaam")]
        public string Name { get; set; }

        [DisplayName("AchterNaam")]
        public string LastName { get; set; }

        [DisplayName("Geboortedatum")]
        public DateViewModel BirthDate { get; set; }

        [DisplayName("Sterftedatum")]
        public DateViewModel Deceased { get; set; }
    }
}
