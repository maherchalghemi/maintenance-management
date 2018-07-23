using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Equipement_DTO
    {
        public int Id { get; set; }
         [Required(ErrorMessage = "empty code")]
        public string CodeEquipement { get; set; }
        public string NumEquipement { get; set; }
         [Required(ErrorMessage = "empty code")]
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
        //Ajouter observation
        public byte[] Photo { get; set; }

        public Nullable<System.DateTime> Date_creation { get; set; }
        public Nullable<System.DateTime> date_Modification { get; set; }

        public string Poste_de_charge_Id { get; set; }
    }
}
