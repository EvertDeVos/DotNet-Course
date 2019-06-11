using Rmdb.Web.Client.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewModels.Movies
{
    public class MovieCreateViewModel
    {
        [Required(ErrorMessage = "Verplicht*")]
        [MinLength(2, ErrorMessage = "Minstens 2 characters")]
        [DisplayName("Titel")]
        public string Title { get; set; }


        [DataType(DataType.MultilineText)]
        [DisplayName("Beschrijving")]
        [MaxLength(512, ErrorMessage = "Beschrijving is te lang (max: 512)")]
        public string Description { get; set; }

        [DisplayName("Premiere")]
        public DateViewModel ReleaseDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayName("Duur")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? RunTime { get; set; }

        [Range(0, 5, ErrorMessage = "Moet een getal tussen 0 en 5 zijn")]
        [DisplayName("Score")]
        public double? Score { get; set; }

        [DisplayName("Kleuren")]
        public bool Color { get; set; }
    }
}
