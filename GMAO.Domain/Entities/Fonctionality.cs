using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Fonctionality
    {
        public Fonctionality()
        {
            this.rights = new List<Right>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Categorie { get; set; }
        public bool IsMenu { get; set; }
        public string Controler { get; set; }
        public string Action { get; set; }
        public string JavaAction { get; set; }
        public string Icon { get; set; }
        public int Module_Id { get; set; }
        public string Group { get; set; }
        public virtual ICollection<Right> rights { get; set; }
    }
}
