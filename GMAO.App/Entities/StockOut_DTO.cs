using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class StockOut_DTO
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string personnel { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string magasin { get; set; }
        public string piece { get; set; }

        public string observation { get; set; }
        public string refExt { get; set; }
        public Nullable<double> qte { get; set; }

    }
}
