using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class OTOutillage_DTO
    {
        public int Id { get; set; }
        public string Codeoutil { get; set; }
        public Nullable<double> qte { get; set; }
        public string designation { get; set; }
        public string codeABarre { get; set; }

        public Nullable<int> Outillage_Id { get; set; }
        public Nullable<int> OT_Id { get; set; }
    }
}
