

using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.EntityConfig
{
    public class RangementMap : EntityTypeConfiguration<Rangement>
    {
        public RangementMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.code)
                .IsRequired();

            this.Property(t => t.Designation)
            .IsRequired();







            // Table & Column Mappings
            this.ToTable("Rangement");



        }
    }
}
