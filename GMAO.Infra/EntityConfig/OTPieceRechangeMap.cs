using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class OTPieceRechangeMap : EntityTypeConfiguration<OTPieceRechange>
    {
        public OTPieceRechangeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties


            this.Property(t => t.Reference)
            .IsRequired();
            this.Property(t => t.Code_OT)
           .IsRequired();
            this.Property(t => t.Qantite_pla)
            .IsRequired();
            this.Property(t => t.PRix_unitaite_pla)
           .IsRequired();
            this.Property(t => t.Quantite_reelle)
            .IsRequired();
            this.Property(t => t.PRix_unitaite_reelle)
            .IsRequired();
            this.Property(t => t.SA_BS)
            .IsRequired();





            // Table & Column Mappings
            this.ToTable("OTPieceRechange");

            //relationShips

            


            this.HasRequired(t => t.ordre_de_travail)
            .WithMany(t => t.oTPieceRechange)
            .HasForeignKey(t => t.OT_Id)
            .WillCascadeOnDelete(true);






        }
    }
}
