using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewModels.Actors
{
    public class ActorViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Naam")]
        public string FullName { get; set; }

        [DisplayName("Leeftijd")]
        public string Age { get; set; }
    }
}
