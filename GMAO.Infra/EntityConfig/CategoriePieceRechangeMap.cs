

using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.EntityConfig
{
    public class CategoriePieceRechangeMap : EntityTypeConfiguration<CategoriePieceRechange>
    {
        public CategoriePieceRechangeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.code)
                .IsRequired();

            this.Property(t => t.Designation)
            .IsRequired();

            this.Property(t => t.Observation);






            // Table & Column Mappings
            this.ToTable("CategoriePieceRechange");



        }
    }
}
