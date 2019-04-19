using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewModels.Movie
{
    public class MovieDetailsViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Titel")]
        public string Title { get; set; }
        [DisplayName("Beschrijving")]
        public string Description { get; set; }

        [DisplayName("Premiere")]
        public DateTime? ReleaseDate { get; set; }
        [DisplayName("Duur")]
        public TimeSpan? RunTime { get; set; }

        [DisplayName("Score")]
        public double? Score { get; set; }
        [DisplayName("Kleuren")]
        public bool Color { get; set; }
    }
}
