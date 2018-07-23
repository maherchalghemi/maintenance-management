using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Personnel_DTO
    {
        public int Id { get; set; }
         [Required(ErrorMessage = "empty code")]
        public string Nom { get; set; }
         [Required(ErrorMessage = "empty code")]
        public string Prenom { get; set; }
         public string NomPrenom { get; set; }
        public Nullable<System.DateTime> DateNaissance { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateAjout { get; set; }
        public string CIN { get; set; }
        public string CNSS { get; set; }
        public string Photo { get; set; }
        public string Sexe { get; set; }
        public Nullable<bool> Integre { get; set; }
        public Nullable<System.DateTime> DebutIntegration { get; set; }
        public Nullable<System.DateTime> FinIntegration { get; set; }
        public int IDService { get; set; }
        public string Tel { get; set; }
         [Required(ErrorMessage = "empty code")]
        public string Matricule { get; set; }
        public string Diplomes { get; set; }
        public string AutresCompetances { get; set; }
        public string AptitudesPhysiques { get; set; }
        public string ExperienceProfessionelles { get; set; }
        public bool Actif { get; set; }
        public Nullable<bool> EstTitulaire { get; set; }
        public Nullable<System.DateTime> DateTitularisation { get; set; }
        public string Grade { get; set; }
        public string NomPre { get; set; }
        public int IDSite { get; set; }
        public int IDSociete { get; set; }
        public Nullable<System.DateTime> CINDELIVRELE { get; set; }
        public string CINDELIVREA { get; set; }
        public string LNAISSANCE { get; set; }
        public string TELDOM { get; set; }
        public string GSM { get; set; }
        public Nullable<System.DateTime> DLIQUIDATION { get; set; }
        public string RIP { get; set; }
        public Nullable<float> MAXCONGE { get; set; }
        //Company 
        public Int32 IdCompany { get; set; }
        public int Site_Id { get; set; }
        public ICollection<Departement_DTO> dep { get; set; }
        
    }
}
