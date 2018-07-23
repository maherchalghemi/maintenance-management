using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Carr_Equip_DTO
    {
        public int Id { get; set; }
        public string Code_cause { get; set; }
        public string libelle { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }
        public Nullable<double> taux_horaire { get; set; }
        public Nullable<bool> panne { get; set; }
    }
}
