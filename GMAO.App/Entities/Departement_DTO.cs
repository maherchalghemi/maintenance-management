using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Departement_DTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "empty code")]
        public string NumDepartement { get; set; }
        [Required(ErrorMessage = "empty code")]
        public string Designation { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }

        public int Site_Id { get; set; }

        public ICollection<Site_DTO> sites { get; set; }
    }
}
