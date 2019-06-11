using Microsoft.AspNetCore.Mvc;
using Rmdb.Web.Client.ViewModels.Actors;
using Rmdb.Web.Client.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewComponents
{
    public class ActorListViewComponent : ViewComponent
    {
        public ActorListViewComponent()
        {

        }
        public IViewComponentResult Invoke(IEnumerable<ActorViewModel> actors)
        {
            return View(actors);
        }
    }
}
