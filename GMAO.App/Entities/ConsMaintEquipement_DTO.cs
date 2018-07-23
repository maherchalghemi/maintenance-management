using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class ConsMaintEquipement_DTO
    {
        public int Id { get; set; }
        public Nullable<int> fréquence { get; set; }
        public string NumEquipement { get; set; }
        public Nullable<System.DateTime> date_fin { get; set; }

        public Nullable<System.DateTime> date_début { get; set; }

        public Nullable<float> alerte { get; set; }
        public string Duré_cons_h { get; set; }
        public string Code_Consigne { get; set; }
        
        public string type { get; set; }
        public string CodeCompt { get; set; }
        public Nullable<int> periodicite { get; set; }
        public Nullable<int> indice_gen { get; set; }
        public Nullable<int> Duré_cons_jr { get; set; }
        public string tYpe_planning { get; set; }
        public Nullable<float> Départ_Compt { get; set; }
    }
}
