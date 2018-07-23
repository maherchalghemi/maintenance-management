using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class PhotoPanneMap : EntityTypeConfiguration<PhotoPanne>
    {
        public PhotoPanneMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties


            this.Property(t => t.photo)
            .IsRequired();
            this.Property(t => t.urlPhoto)
           .IsRequired();
           



            // Table & Column Mappings
            this.ToTable("PhotoPanne");

            //relationShips

            this.HasRequired(t => t.equipement)
            .WithMany(t => t.photoPanne)
            .HasForeignKey(t => t.Equipement_Id)
            .WillCascadeOnDelete(true);

            this.HasRequired(t => t.ordre_de_travails)
                .WithMany(t => t.photoPanne)
                .HasForeignKey(t => t.OT_Id)
                .WillCascadeOnDelete(true);

        }
    }
}
