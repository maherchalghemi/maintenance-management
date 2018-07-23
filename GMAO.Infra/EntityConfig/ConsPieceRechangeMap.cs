using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class ConsPieceRechangeMap : EntityTypeConfiguration<ConsPieceRechange>
    {
        public ConsPieceRechangeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);




            // Table & Column Mappings
            this.ToTable("ConsPieceRechange");

            //relationShips
            this.HasRequired(t => t.listConsM)
                    .WithMany(t => t.consPieceRechange)
                    .HasForeignKey(t => t.ListConsM_Id)
                    .WillCascadeOnDelete(true);


           

        }
    }
}
