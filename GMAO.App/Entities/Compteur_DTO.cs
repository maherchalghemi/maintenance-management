using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Compteur_DTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "empty code")]
        public string codeCompt { get; set; }
        public string unite { get; set; }
        public string valeur_compteur_max { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }
    }
}
