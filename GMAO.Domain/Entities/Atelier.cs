using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Atelier
    {

       

        public int Id { get; set; }

        public string Libelle_atelier { get; set; }
        public string site { get; set; }
        public string code_atelier { get; set; }
        
        public string Designation { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }

        public string Departement_Id { get; set; }
        

       
    }
}
