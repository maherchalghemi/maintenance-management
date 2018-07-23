using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class OTEmploye
    {

        public int Id { get; set; }
        //public string NumEmploye { get; set; }
        public string Code_OT { get; set; }
        public string Action { get; set; }
        public string Duree_planifie { get; set; }
        public Nullable<System.DateTime> Date_debut_prevu { get; set; }
        public string Duree_planifie_jr { get; set; }
        public Nullable<double> Cout_planifie { get; set; }
        public string Dure_reelle { get; set; }
        public Nullable<System.DateTime> Date_debut_reelle { get; set; }
        public Nullable<double> Cout_MO { get; set; }
        public Nullable<double> Cout_MO_P { get; set; }
        public string Dure_reelle_jr { get; set; }
        public Nullable<int> Personnel_Id { get; set; }

        public virtual Personnel personnel { get; set; }

        public Nullable<int> OT_Id { get; set; }
        public virtual Ordre_de_travail ordre_de_travail { get; set; }
    }
}
