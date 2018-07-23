using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Compteur
    {
       
        public int Id { get; set; }

        public string codeCompt { get; set; }
        public string unite { get; set; }
        public string valeur_compteur_max { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }

        

    }
}
