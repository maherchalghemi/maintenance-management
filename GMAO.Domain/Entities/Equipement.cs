using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Equipement
    {
        public Equipement()
        {
            this.dec_Pannes = new List<Dec_Panne>();
            this.ordres_de_travail = new List<Ordre_de_travail>();
            this.testScheduler = new List<TestScheduler>();
            this.photoPanne = new List<PhotoPanne>();

            this.consigne_maintenance = new List<Consigne_maintenance>();
            this.listconsMaintEquipement = new List<ListeconsMaintEquipement>();
        }
        public int Id { get; set; }
        public string CodeEquipement { get; set; }
        public string NumEquipement { get; set; }
        public string Designation { get; set; }
        //IDENTIFIED
        public string NumModel { get; set; }
        public string NumSerie { get; set; }
        public string Marque { get; set; }
        public string Description { get; set; }
        //Parametre
        public string Code_poste { get; set; }
        public string Code_categorie { get; set; }
        public string codeclient { get; set; }
        public string EtatEquipement { get; set; }
        public string nb_eq { get; set; }
        public string Nature_Heure_Travail { get; set; }
        //Photo
        public byte[] Photo { get; set; }
        
        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }

        public string Poste_de_charge_Id { get; set; }
        

        public virtual ICollection<Dec_Panne> dec_Pannes { get; set; }
        public virtual ICollection<Ordre_de_travail> ordres_de_travail { get; set; }
        public virtual ICollection<TestScheduler> testScheduler { get; set; }
        public virtual ICollection<PhotoPanne> photoPanne { get; set; }

        public virtual ICollection<Consigne_maintenance> consigne_maintenance { get; set; }
        public virtual ICollection<ListeconsMaintEquipement> listconsMaintEquipement { get; set; }
    }
}
