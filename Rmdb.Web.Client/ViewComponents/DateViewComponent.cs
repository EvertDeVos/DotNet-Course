using Microsoft.AspNetCore.Mvc;
using Rmdb.Web.Client.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewComponents.DateTimeViewComponent
{
    [ViewComponent(Name = "DateInput")]
    public class DateViewComponent : ViewComponent
    {
        public DateViewComponent()
        {

        }
        public IViewComponentResult Invoke(DateViewModel date)
        {
            return View(date);
        }
    }
}
