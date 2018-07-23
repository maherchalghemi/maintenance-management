using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class EmplacementMap : EntityTypeConfiguration<Emplacement>
    {
        public EmplacementMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Code_Emplacement)
                .IsRequired();
            this.Property(t => t.Designation)
                .IsRequired();
            this.Property(t => t.magasin);






            // Table & Column Mappings
            this.ToTable("Emplacement");



        }
    }
}
