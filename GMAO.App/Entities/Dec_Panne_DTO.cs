using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Dec_Panne_DTO
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Heure_Dec_Panne { get; set; }
        public Nullable<System.DateTime> Date_Dec_Panne { get; set; }
        public string Heure_Arr_Panne { get; set; }
        public Nullable<System.DateTime> Date_Arr_Panne { get; set; }
        public string Symtome { get; set; }
        public string Action_Imediate { get; set; }
        public string Diagnostic { get; set; }

        public int Id_Personnel { get; set; }
        
        public int Id_Equipement { get; set; }
    }
}
