using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Carr_Equip
    {
        public Carr_Equip()
        {
            this.ordres_de_travail = new List<Ordre_de_travail>();
        }

        public int Id { get; set; }
        public string Code_cause { get; set; }
        public string libelle { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }
        public Nullable<double> taux_horaire { get; set; }
        public Nullable<bool> panne { get; set; }

        public virtual ICollection<Ordre_de_travail> ordres_de_travail { get; set; }
    }
}
