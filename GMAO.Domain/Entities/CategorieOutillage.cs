using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class CategorieOutillage
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public string code { get; set; }
        public string Observation { get; set; }

        public string type { get; set; }
    }
}
