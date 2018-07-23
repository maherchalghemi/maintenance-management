using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Composant
    {
        public int Id { get; set; }
        public string codeComposant { get; set; }
        public string libelle { get; set; }
        public int? NumLot { get; set; }
        public string codeBarre { get; set; }
        public Nullable<System.DateTime> Date_reception { get; set; }
        public int? delaiObtention { get; set; }
        public int? NbrExemplaire { get; set; }
    }
}
