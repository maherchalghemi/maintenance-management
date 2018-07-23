using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Poste_de_charge_DTO
    {
        public int Id { get; set; }
        public float? dureeJr { get; set; }
       [Required(ErrorMessage = "empty code")]
        public string code_poste { get; set; }
        public string NbEquipe { get; set; }
        [Required(ErrorMessage = "empty code")]
        public string Designation { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }

        public string Atelier { get; set; }
        public ICollection<Atelier_DTO> ateliers { get; set; }

        
    }
}
