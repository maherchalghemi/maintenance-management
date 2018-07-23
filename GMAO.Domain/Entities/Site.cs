using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Site
    {
      

        public int Id { get; set; }
        public string Name { get; set; }

        /*Champs siteGMAO*/
        public string code_site { get; set; }
        public string adresse_site { get; set; }
        public string no_tel { get; set; }
        public string no_fax { get; set; }
        public string email { get; set; }
        public string Ville { get; set; }
        public string pays { get; set; }
        public string Code_postale { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }
        /*******************/

       
    //    public virtual ICollection<Fournisseur> fournisseurs { get; set; }
       
        

    }
}
