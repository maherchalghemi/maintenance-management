using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.EntityConfig
{
    public class DeviseMap : EntityTypeConfiguration<Devise>
    {
        public DeviseMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.codeDevise)
                .IsRequired();
            this.Property(t => t.Designation)
                .IsRequired();
            this.Property(t => t.decimale);
            this.Property(t => t.nb);



            // Table & Column Mappings
            this.ToTable("Devise");



        }
    }
}
