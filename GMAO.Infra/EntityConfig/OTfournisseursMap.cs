using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class OTfournisseursMap : EntityTypeConfiguration<OTfournisseurs>
    {
        public OTfournisseursMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties


            this.Property(t => t.date_debut_prevu_ext)
            .IsRequired();
            this.Property(t => t.Duree_ext_planifie_jr)
           .IsRequired();
            this.Property(t => t.duree_Ext_planifie_h)
            .IsRequired();
            this.Property(t => t.cout_Intervenant_planifie)
           .IsRequired();
            this.Property(t => t.cout_Intervenant_reel)
            .IsRequired();
            this.Property(t => t.date_debut_reelle_ext)
           .IsRequired();
            this.Property(t => t.Duree_ext_reel_jr)
            .IsRequired();
            this.Property(t => t.duree_ext_reel_h)
           .IsRequired();
            this.Property(t => t.Action)
            .IsRequired();




            // Table & Column Mappings
            this.ToTable("OTfournisseurs");

            //relationShips

            this.HasRequired(t => t.fournisseurs)
            .WithMany(t => t.OTfournisseurs)
            .HasForeignKey(t => t.Fournisseurs_Id)
            .WillCascadeOnDelete(true);


            this.HasRequired(t => t.ordre_de_travails)
            .WithMany(t => t.oTfournisseurs)
            .HasForeignKey(t => t.OT_Id)
            .WillCascadeOnDelete(true);






        }
    }
}
