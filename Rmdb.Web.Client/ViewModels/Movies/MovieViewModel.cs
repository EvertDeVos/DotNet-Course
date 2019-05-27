using Rmdb.Web.Client.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewModels.Movies
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Titel")]
        public string Title { get; set; }

        [DisplayName("Score")]
        public double Score { get; set; }


        [DisplayName("Premiere")]
        public DateViewModel ReleaseDate { get; set; }
    }
}
