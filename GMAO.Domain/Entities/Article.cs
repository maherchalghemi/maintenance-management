using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Article
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public int Nature { get; set; }
        public Nullable<float> PrixRevient { get; set; }
        public int IDFamille { get; set; }
        public string CractTechnique { get; set; }
        public int IDSite { get; set; }
        public int IDSociete { get; set; }
        public int Company_Id { get; set; }
        public string Reference { get; set; }
        public virtual Company company { get; set; }
    }
}
