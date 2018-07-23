using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Departement
    {
        
        public int Id { get; set; }
        public string NumDepartement { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }

        

       
    }
}
