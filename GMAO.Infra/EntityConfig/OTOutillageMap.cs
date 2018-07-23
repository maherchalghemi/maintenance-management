using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class OTOutillageMap : EntityTypeConfiguration<OTOutillage>
    {
        public OTOutillageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties


            this.Property(t => t.Codeoutil)
            .IsRequired();
            this.Property(t => t.qte)
           .IsRequired();
            this.Property(t => t.designation)
            .IsRequired();
            this.Property(t => t.codeABarre)
           .IsRequired();




            // Table & Column Mappings
            this.ToTable("OTOutillage");

            //relationShips

            


            this.HasRequired(t => t.ordre_de_travail)
            .WithMany(t => t.oTOutillage)
            .HasForeignKey(t => t.OT_Id)
            .WillCascadeOnDelete(true);






        }
    }
	
}
