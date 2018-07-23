using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Site_DTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "empty code")]
        public string Name { get; set; }

        /*Champs siteGMAO*/
        [Required(ErrorMessage = "empty code")]
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

        public int Company_Id { get; set; }
        
    }
}
