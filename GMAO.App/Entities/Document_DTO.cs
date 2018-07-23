using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
   public class Document_DTO
    {
        public int Id { get; set; }
       [Required(ErrorMessage = "required")]
        public string codeDocument { get; set; }
        public string typeDocument { get; set; }
       [Required(ErrorMessage = "required")]
        public string libelle { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public string Edition { get; set; }
        public string lien { get; set; }
    }
}
