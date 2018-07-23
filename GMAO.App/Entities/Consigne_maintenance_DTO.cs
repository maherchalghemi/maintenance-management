using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Consigne_maintenance_DTO
    {
        public int Id { get; set; }

        public string Description { get; set; }
        //IDDocument INTEGER  NOT NULL ,

        public string Designation { get; set; }
        public string Cod_doc { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }
        public string niveau { get; set; }

        public byte[] photo { get; set; }
        public Nullable<int> Nb_interv_suggéré { get; set; }


        public string Duré_cons_h { get; set; }
        public string Code_Consigne { get; set; }


        public Nullable<int> Duré_cons_jr { get; set; }
        public ICollection<Document_DTO> documents { get; set; }

    }
}
