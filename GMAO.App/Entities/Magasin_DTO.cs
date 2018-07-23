using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{

    public class Magasin_DTO
    {
        public int Id { get; set; }
        public string Code_magasin { get; set; }
        public string libelle { get; set; }
        public string Adresse { get; set; }
        public string tel { get; set; }
        public string obsrvation { get; set; }
        public ICollection<Emplacement_DTO> emplacements { get; set; }
    }
}
