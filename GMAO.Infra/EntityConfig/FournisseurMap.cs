using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class FournisseurMap : EntityTypeConfiguration<Fournisseur>
    {
        public FournisseurMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Code_Fournisseur)
                .IsRequired();
            this.Property(t => t.Code_Devise);
           
            this.Property(t => t.Adresse);
           
            this.Property(t => t.code_postal);
           
            this.Property(t => t.Nom)
           .IsRequired();

            this.Property(t => t.Ville);
                
            this.Property(t => t.Pays);


            this.Property(t => t.TEL);
           
            this.Property(t => t.FAX);
           

            this.Property(t => t.email);
            
            this.Property(t => t.Site_Web);
           
            this.Property(t => t.Compte_Courant_Bancaire);
           
            this.Property(t => t.matricule_fiscale);

            this.Property(t => t.Date_création);

            this.Property(t => t.Date_Modification);



            this.Property(t => t.GSM);

            this.Property(t => t.Domaine);

            this.Property(t => t.Date);

            this.Property(t => t.civilité);

            this.Property(t => t.Banque);


            this.Property(t => t.Domiciliation_Bancaire);

            this.Property(t => t.IBAN);
           
            this.Property(t => t.code_douane);
           
            this.Property(t => t.Code_tva);
          
            this.Property(t => t.adresse_livraison);
           

            this.Property(t => t.adresse_facturation);
            
            this.Property(t => t.Ville_L);
           
            this.Property(t => t.Ville_F);
           
            this.Property(t => t.ccP_L);
           
            this.Property(t => t.ccp_F);
           
            this.Property(t => t.Pays_L);
            


            this.Property(t => t.adresse_usine);
                
            this.Property(t => t.pays_usine);
           
            this.Property(t => t.ville_usine);
            
            this.Property(t => t.ccp_usine);
           
            this.Property(t => t.tel_usine);
            
            this.Property(t => t.fax_usine);
            
            this.Property(t => t.email_usine);
            

            this.Property(t => t.Pays_F);
            
            this.Property(t => t.observation);
           
            this.Property(t => t.SWIFT);
           
            this.Property(t => t.téL_L);
           
            this.Property(t => t.téL_F);
           

            this.Property(t => t.FAX_l);
            
            this.Property(t => t.FAX_F);
           
            this.Property(t => t.EMAIL_L);
           
            this.Property(t => t.EMAIL_F);
           
            this.Property(t => t.Délai_confirmation_CDE);
           
            this.Property(t => t.Num_client);
            


            this.Property(t => t.Etat_Fournisseur);
            
            this.Property(t => t.TVA);
           
            this.Property(t => t.nb_facture);
           
            this.Property(t => t.nb_bl);
           
            this.Property(t => t.escompte);
           




            // Table & Column Mappings
            this.ToTable("Fournisseur");

            //relationShips
           this.HasOptional(t => t.Site)
                    .WithMany()
                    .HasForeignKey(t => t.Site_Id)
                    .WillCascadeOnDelete(false);





        }
    }
}
