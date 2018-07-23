using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class OTOutillage
    {
        public int Id { get; set; }
        public string Codeoutil { get; set; }
        public Nullable<double> qte { get; set; }
        public string designation { get; set; }
        public string codeABarre { get; set; }

        
        public Nullable<int> OT_Id { get; set; }
        public virtual Ordre_de_travail ordre_de_travail { get; set; }
    }
}
