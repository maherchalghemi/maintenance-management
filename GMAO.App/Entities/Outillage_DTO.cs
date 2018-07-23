using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Outillage_DTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "empty code")]
        public string codeoutil { get; set; }
        [Required(ErrorMessage = "empty code")]
        public string code_barre { get; set; }
        public string designation { get; set; }
        public Nullable<System.DateTime> date_achat { get; set; }
        public string caractéristiques { get; set; }
        public string observation { get; set; }
        public Nullable<System.DateTime> Date_création { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }
        public string Code_famille { get; set; }
        public string Nom { get; set; }
        public Int64 Nb_exp { get; set; }
        public string etat_outillage { get; set; }
        public byte LONGBLOB { get; set; }
        public int IDAtelier { get; set; }
        public float prix_U { get; set; }
        public string Code_barre_Ext { get; set; }
        public string Code_Fournisseur { get; set; }
        public int nb_eq { get; set; }
        public int IDLieuRangement { get; set; }
        public int Nature_Heure_Travail { get; set; }
        public string N_série { get; set; }

        public int Site_Id { get; set; }
    }
}
