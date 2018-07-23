using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
   public partial class Document
    {
       public int Id { get; set; }
       public string codeDocument { get; set; }
       public string typeDocument { get; set; }
       public string libelle { get; set; }
       public Nullable<System.DateTime> Date_creation { get; set; }
       public string Edition { get; set; }
       public string lien { get; set; }


    }
}
