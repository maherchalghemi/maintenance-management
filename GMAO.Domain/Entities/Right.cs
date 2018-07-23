using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Right
    {
        public int Id { get; set; }
        public int GroupUser_Id { get; set; }
        public int fonctionality_Id { get; set; }
        public virtual Fonctionality fonctionality { get; set; }
        public virtual GroupUser groupUser { get; set; }
    }
}
