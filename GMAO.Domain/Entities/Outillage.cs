using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Outillage
    {
      
        public int Id { get; set; }
        public string codeoutil { get; set; }
        public string code_barre { get; set; }
        public string designation { get; set; }
        public Nullable<System.DateTime> date_achat { get; set; }
        public string caractéristiques { get; set; }
        public string observation { get; set; }
        public Nullable<System.DateTime> Date_création { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }
        public string Code_famille { get; set; }
        public string Nom { get; set; }
        public Int64? Nb_exp { get; set; }
        public string etat_outillage { get; set; }
        public byte? LONGBLOB { get; set; }
        public int? IDAtelier { get; set; }
        public float? prix_U { get; set; }
        public string Code_barre_Ext { get; set; }
        public string Code_Fournisseur { get; set; }
        public int? nb_eq { get; set; }
        public string IDLieuRangement { get; set; }
        public int? Nature_Heure_Travail { get; set; }
        public string N_série { get; set; }

       
    }
}
