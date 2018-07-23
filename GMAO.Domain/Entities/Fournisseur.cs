using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Fournisseur
    {
        public Fournisseur()
        {
            this.OTfournisseurs = new List<OTfournisseurs>();
            //this.Ordre_de_travail = new List<ordre_de_travail>();
        }
        public int Id { get; set; }

       
        public string Code_Fournisseur { get; set; }
        public string Code_Devise { get; set; }
        public string Adresse { get; set; }
        public string code_postal { get; set; }
        
        public string Nom { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string TEL { get; set; }
        public string FAX { get; set; }
        public string email { get; set; }
        public string Site_Web { get; set; }
        public string Compte_Courant_Bancaire { get; set; }
        public string matricule_fiscale { get; set; }
        public Nullable<System.DateTime> Date_création { get; set; }
        public Nullable<System.DateTime> Date_Modification { get; set; }
        public string GSM { get; set; }
        public string Domaine { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string civilité { get; set; }

        public string Banque { get; set; }
        public string Domiciliation_Bancaire { get; set; }
        public string IBAN { get; set; }

        public string code_douane { get; set; }
        public string Code_tva { get; set; }

        public string adresse_usine { get; set; }
        public string pays_usine { get; set; }
        public string ville_usine { get; set; }
        public string ccp_usine { get; set; }
        public string tel_usine { get; set; }
        public string fax_usine { get; set; }
        public string email_usine { get; set; }



        public string adresse_livraison { get; set; }
        public string adresse_facturation { get; set; }
        public string Ville_L { get; set; }
        public string Ville_F { get; set; }
        public string ccP_L { get; set; }
        public string ccp_F { get; set; }
        public string Pays_L { get; set; }
        public string Pays_F { get; set; }
        public string observation { get; set; }
        public string SWIFT { get; set; }
        public string téL_L { get; set; }
        public string téL_F { get; set; }
        public string FAX_l { get; set; }
        public string FAX_F { get; set; }
        public string EMAIL_L { get; set; }
        public string EMAIL_F { get; set; }
        public string Délai_confirmation_CDE { get; set; }

        public string Num_client { get; set; }
        public string Etat_Fournisseur { get; set; }
        public float? TVA { get; set; }

        public int? nb_facture { get; set; }
        public int? nb_bl { get; set; }
        public int? escompte { get; set; }

        //public int IDCatégorie_fournisseur   { get; set; }
        //public int IDMode_Paiment   { get; set; }
        //public int IDCondition_Paiement   { get; set; }
        //public int IDMode_Livraison   { get; set; }
        //public int IDCondition_Livraison   { get; set; }

        /**********************public string Code_Siret  { get; set; }*/

        public int? Site_Id { get; set; }
        public virtual Site Site { get; set; }
        //public int délai_livraison { get; set; }
        public virtual ICollection<OTfournisseurs> OTfournisseurs { get; set; }
        //public virtual ICollection<ordre_de_travail> Ordre_de_travail { get; set; }
    }
}
