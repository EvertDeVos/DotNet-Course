using Rmdb.Web.Client.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewModels.Actors
{
    public class ActorUpdateViewModel
    {
        [DisplayName("Voornaam*")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Verplicht")]
        public string Name { get; set; }

        [DisplayName("Achternaam*")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Verplicht")]
        public string LastName { get; set; }

        [DisplayName("Geboortedatum")]
        public DateViewModel BirthDate { get; set; }

        [DisplayName("Sterftedatum")]
        public DateViewModel Deceased { get; set; }
    }
}
