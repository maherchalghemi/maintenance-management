using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class PhotoPanne_DTO
    {
        public int Id { get; set; }
        public byte[] photo { get; set; }

        public string urlPhoto { get; set; }

        public Nullable<int> Equipement_Id { get; set; }
        
        public Nullable<int> OT_Id { get; set; }
        
    }
}
