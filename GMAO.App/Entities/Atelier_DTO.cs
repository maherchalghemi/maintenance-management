using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Atelier_DTO
    {
        public int Id { get; set; }

        public string Libelle_atelier { get; set; }
        public string nbr_ouvrier { get; set; }
        [Required(ErrorMessage = "empty code")]
        public string code_atelier { get; set; }
        public string cout_std_MO { get; set; }
        public string cout_std_machine { get; set; }
        [Required(ErrorMessage = "empty code")]
        public string Designation { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }

        public string Departement_Id { get; set; }
    }
}
