using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class PhotoPanne
    {
        public int Id { get; set; }
        public byte[] photo { get; set; }

        public string urlPhoto { get; set; }

        public Nullable<int> Equipement_Id { get; set; }
        public virtual Equipement equipement { get; set; }

        public Nullable<int> OT_Id { get; set; }
        public virtual Ordre_de_travail ordre_de_travails { get; set; }
    }
}
