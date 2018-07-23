using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Poste_de_charge
    {
       
        public int Id { get; set; }
        public float? dureeJr { get; set; }
        public string code_poste { get; set; }
        public string NbEquipe { get; set; }
        public string Designation { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }

        public string Atelier { get; set; }
       
      
    }
}
