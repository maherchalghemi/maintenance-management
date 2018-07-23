using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class ConsPieceRechange
    {
        public int Id { get; set; }
        public Nullable<int> ListConsM_Id { get; set; }
        public virtual ListeconsMaintEquipement listConsM { get; set; }
       
    }
}
