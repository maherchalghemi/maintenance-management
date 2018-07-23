using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class OTfournisseurs
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> date_debut_prevu_ext { get; set; }
        public string Duree_ext_planifie_jr { get; set; }
        public string duree_Ext_planifie_h { get; set; }
        public Nullable<double> cout_Intervenant_planifie { get; set; }

        public Nullable<double> cout_Intervenant_reel { get; set; }
        public Nullable<System.DateTime> date_debut_reelle_ext { get; set; }
        public string Duree_ext_reel_jr { get; set; }
        public string duree_ext_reel_h { get; set; }
        public string Action { get; set; }
        public Nullable<int> Fournisseurs_Id { get; set; }

        public virtual Fournisseur fournisseurs { get; set; }

        public Nullable<int> OT_Id { get; set; }
        public virtual Ordre_de_travail ordre_de_travails { get; set; }
    }
}
