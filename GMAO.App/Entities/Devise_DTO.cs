using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Devise_DTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "empty code")]
        public string codeDevise { get; set; }
        [Required(ErrorMessage = "empty code")]
        public string Designation { get; set; }

        public string decimale { get; set; }
        public int? nb { get; set; }
    }
}
