using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class OutillageMap : EntityTypeConfiguration<Outillage>
    {
        public OutillageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties


            this.Property(t => t.codeoutil)
            .IsRequired();
            this.Property(t => t.code_barre);
           
            this.Property(t => t.designation)
            .IsRequired();
            this.Property(t => t.date_achat);
           
            this.Property(t => t.caractéristiques);
           
            this.Property(t => t.observation);
           
            this.Property(t => t.Date_création);
            
            this.Property(t => t.date_Modification);
            
            this.Property(t => t.Code_famille);
            
            this.Property(t => t.Nom);
            
            this.Property(t => t.Nb_exp);
            
            this.Property(t => t.etat_outillage);
            
            this.Property(t => t.LONGBLOB);
            
            this.Property(t => t.IDAtelier);
            
            this.Property(t => t.prix_U);
            
            this.Property(t => t.Code_barre_Ext);
           
            this.Property(t => t.Code_Fournisseur);
            
            this.Property(t => t.nb_eq);
            
            this.Property(t => t.IDLieuRangement);
            
            this.Property(t => t.Nature_Heure_Travail);
            
            this.Property(t => t.N_série);
            





            // Table & Column Mappings
            this.ToTable("Outillage");

            //relationShips

           


        }
    }
}
