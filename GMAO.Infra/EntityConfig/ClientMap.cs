using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CompteActif);
                

            this.Property(t => t.Banque);


            this.Property(t => t.nb_bl);


            this.Property(t => t.NCompte);


            this.Property(t => t.civilite);
                

            this.Property(t => t.DateCreation);
                

            this.Property(t => t.DateModification);

            this.Property(t => t.MatriculeFiscal);

            this.Property(t => t.CodeInterne)
            .IsRequired();

            this.Property(t => t.NomContact)
            .IsRequired();

            this.Property(t => t.Email);


            this.Property(t => t.Tel);

            this.Property(t => t.EmailF);


            this.Property(t => t.TelF);

            this.Property(t => t.Domiciliation);

            this.Property(t => t.Adresse1);

            this.Property(t => t.Adresse2);

            this.Property(t => t.nbFacture);

            this.Property(t => t.delaiLiv);
            this.Property(t => t.Fax);
            this.Property(t => t.loex);
            this.Property(t => t.FaxF);
            this.Property(t => t.escompte);
            this.Property(t => t.IBAN);
            this.Property(t => t.observation);
            this.Property(t => t.UR);
            this.Property(t => t.RefFour);
            this.Property(t => t.siret);
            this.Property(t => t.codeDouane);
            this.Property(t => t.codeTVA);
            this.Property(t => t.SWIFT);
            this.Property(t => t.VILLE);
            this.Property(t => t.VILLEF);
            this.Property(t => t.CCP);
            this.Property(t => t.CCPF);


            // Table & Column Mappings
            this.ToTable("Client");

            
            
            


        }

    }
}
