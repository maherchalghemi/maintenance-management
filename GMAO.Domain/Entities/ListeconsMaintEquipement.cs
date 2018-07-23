using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class ListeconsMaintEquipement
    {
        public ListeconsMaintEquipement()
        {
            this.consPieceRechange = new List<ConsPieceRechange>();
        }
        public int Id { get; set; }

        public string Description { get; set; }
        //IDDocument INTEGER  NOT NULL ,
        public string libellé { get; set; }
        //public string code_consigne { get; set; }
        public string Designation { get; set; }
        public string Cod_doc { get; set; }
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }
        public string niveau { get; set; }
        public Nullable<int> Duree_Standard_JR { get; set; }
        public string Duree_Standard_hhmm { get; set; }
        public byte[] photo { get; set; }
        public Nullable<int> Nb_interv_suggéré { get; set; }
        public Nullable<int> fréquence { get; set; }
        public string NumEquipement { get; set; }
        public Nullable<System.DateTime> date_fin { get; set; }

        public Nullable<System.DateTime> date_début { get; set; }

        public string STime { get; set; }
        public string ETime { get; set; }
        public Nullable<float> alerte { get; set; }
        public string Duré_cons_h { get; set; }
        public string Code_Consigne { get; set; }
        //IDCONSIGNE_EQUIPEMENT INTEGER  PRIMARY KEY ,
        public string type { get; set; }
        public string CodeCompt { get; set; }
        public Nullable<int> periodicite { get; set; }
        public Nullable<int> indice_gen { get; set; }
        public Nullable<int> Duré_cons_jr { get; set; }
        public string tYpe_planning { get; set; }
        public Nullable<float> Départ_Compt { get; set; }

        public Nullable<int> Equipements_Id { get; set; }
        public virtual Equipement equipement { get; set; }

        public virtual ICollection<ConsPieceRechange> consPieceRechange { get; set; }


    }
}
