using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class PieceRechange
    {
        public int Id { get; set; }
        public string CodeBarreFab { get; set; }
        public float PrixHT { get; set; }
        public Int64 QteReappro { get; set; }
        public string unité { get; set; }

        
        public string CodePiece { get; set; }
       
        public string Designation { get; set; }

        public string CodeBarre { get; set; }

        public string Description { get; set; }
        public string code_Fournisseur { get; set; }
        public string CodeCatgorie { get; set; }
        public double stock { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }
        public byte LONGBLOB { get; set; }
        public double stock_scurit { get; set; }
        public string Etat_Pice { get; set; }

    }
}
