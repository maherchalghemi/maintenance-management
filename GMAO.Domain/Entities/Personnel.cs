using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Personnel
    {
        public Personnel()
        {
            this.dec_Pannes = new List<Dec_Panne>();
            this.oTEmployes = new List<OTEmploye>();
            this.ordre_de_travails = new List<Ordre_de_travail>();
            this.testSchedulers = new List<TestScheduler>();
            this.users = new List<User>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
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
        public int? IDService { get; set; }
        public string Tel { get; set; }
        public string Matricule { get; set; }
        public string Diplomes { get; set; }
        public string AutresCompetances { get; set; }
        public string AptitudesPhysiques { get; set; }
        public string ExperienceProfessionelles { get; set; }
        public Nullable<bool> Actif { get; set; }
        public Nullable<bool> EstTitulaire { get; set; }
        public Nullable<System.DateTime> DateTitularisation { get; set; }
        public string Grade { get; set; }
        public string NomPre { get; set; }
        public int? IDSite { get; set; }
        public int? IDSociete { get; set; }
        public Nullable<System.DateTime> CINDELIVRELE { get; set; }
        public string CINDELIVREA { get; set; }
        public string LNAISSANCE { get; set; }
        public string TELDOM { get; set; }
        public string GSM { get; set; }
        public Nullable<System.DateTime> DLIQUIDATION { get; set; }
        public string RIP { get; set; }
        public Nullable<float> MAXCONGE { get; set; }
        //Company 
        public Int32? IdCompany { get; set; }
       
        
        public virtual ICollection<User> users { get; set; }

        public virtual ICollection<Dec_Panne> dec_Pannes { get; set; }
        public virtual ICollection<OTEmploye> oTEmployes { get; set; }
        public virtual ICollection<Ordre_de_travail> ordre_de_travails { get; set; }
        public virtual ICollection<TestScheduler> testSchedulers { get; set; }

    }
}
