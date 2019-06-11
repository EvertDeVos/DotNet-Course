using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewModels.Shared
{


    public class DateViewModel
    {
        [Display(Name = "Dag")]
        public int Day { get; set; } = DateTime.Now.Day;

        [Display(Name = "Maand")]
        public int Month { get; set; } = DateTime.Now.Month;

        [Display(Name = "Jaar")]
        public int Year { get; set; } = DateTime.Now.Year;
    }
}
