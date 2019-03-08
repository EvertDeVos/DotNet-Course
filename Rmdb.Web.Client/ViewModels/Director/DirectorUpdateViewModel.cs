using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rmdb.Web.Client.ViewModels.Director
{
    public class DirectorUpdateViewModel
    {
        [DisplayName("Voornaam*")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Verplicht")]
        public string Name { get; set; }

        [DisplayName("Achternaam*")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Verplicht")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Geboortedatum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }


        [DataType(DataType.Date)]
        [DisplayName("Sterftedatum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Deceased { get; set; }
    }
}
