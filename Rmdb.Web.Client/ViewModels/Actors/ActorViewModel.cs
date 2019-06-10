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

        public string FullName { get; set; }

        public string Age { get; set; }
    }
}
