using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Devise
    {
        public int Id { get; set; }
        public string codeDevise { get; set; }
        public string Designation { get; set; }

        public string decimale { get; set; }
        public int? nb { get; set; }
    }
}
