using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public  class Composant_DTO
    {
        public int Id { get; set; }
         [Required(ErrorMessage = "empty code")]
        public string codeComposant { get; set; }
        public string libelle { get; set; }
        public int NumLot { get; set; }
        public string codeBarre { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Date_reception { get; set; }
        public int delaiObtention { get; set; }
        public int NbrExemplaire { get; set; }
    }
}
