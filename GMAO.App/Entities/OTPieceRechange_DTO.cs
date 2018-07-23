using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class OTPieceRechange_DTO
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Code_OT { get; set; }

        public Int64 Qantite_pla { get; set; }
        public Nullable<float> PRix_unitaite_pla { get; set; }

        public Int64 Quantite_reelle { get; set; }
        public Nullable<float> PRix_unitaite_reelle { get; set; }

        public string SA_BS { get; set; }

        public Nullable<int> PieceRechange_Id { get; set; }

        public Nullable<int> OT_Id { get; set; }
        
    }
}
