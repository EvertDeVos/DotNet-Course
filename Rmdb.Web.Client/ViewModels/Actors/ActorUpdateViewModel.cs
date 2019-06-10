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
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateViewModel BirthDate { get; set; }

        public DateViewModel Deceased { get; set; }
    }
}
