using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Emplacement
    {
        public int Id { get; set; }
        public string Code_Emplacement { get; set; }
        public string Designation { get; set; }
        public string magasin { get; set; }
    }
}
