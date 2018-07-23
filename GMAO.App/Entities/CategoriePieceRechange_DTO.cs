using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class CategoriePieceRechange_DTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "required")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "required")]
        public string code { get; set; }
        public string Observation { get; set; }
    }
}
