using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class OTEmployeMap : EntityTypeConfiguration<OTEmploye>
    {
        public OTEmployeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties


            this.Property(t => t.Code_OT)
            .IsRequired();
            this.Property(t => t.Action)
           .IsRequired();
            this.Property(t => t.Duree_planifie)
            .IsRequired();
            this.Property(t => t.Date_debut_prevu)
           .IsRequired();
            this.Property(t => t.Duree_planifie_jr)
            .IsRequired();
            this.Property(t => t.Cout_planifie)
           .IsRequired();
            this.Property(t => t.Dure_reelle)
            .IsRequired();
            this.Property(t => t.Date_debut_reelle)
           .IsRequired();
            this.Property(t => t.Cout_MO)
            .IsRequired();
            this.Property(t => t.Cout_MO_P)
           .IsRequired();
            this.Property(t => t.Dure_reelle_jr)
            .IsRequired();



            // Table & Column Mappings
            this.ToTable("OTEmploye");

            //relationShips

            this.HasRequired(t => t.personnel)
            .WithMany(t => t.oTEmployes)
            .HasForeignKey(t => t.Personnel_Id)
            .WillCascadeOnDelete(true);


            this.HasRequired(t => t.ordre_de_travail)
            .WithMany(t => t.oTEmployes)
            .HasForeignKey(t => t.OT_Id)
            .WillCascadeOnDelete(true);






        }
    }
}
