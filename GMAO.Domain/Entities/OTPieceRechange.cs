using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class OTPieceRechange
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Code_OT { get; set; }

        public Int64 Qantite_pla { get; set; }
        public Nullable<float> PRix_unitaite_pla { get; set; }

        public Int64 Quantite_reelle { get; set; }
        public Nullable<float> PRix_unitaite_reelle { get; set; }


        //public int ligne_sortie_Id { get; set; }
        public string SA_BS { get; set; }

       

        public Nullable<int> OT_Id { get; set; }
        public virtual Ordre_de_travail ordre_de_travail { get; set; }
    }
}
