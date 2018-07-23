using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class AtelierMap : EntityTypeConfiguration<Atelier>
    {
        public AtelierMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
                
            this.Property(t => t.code_atelier)
                .IsRequired();
            this.Property(t => t.site);
                
                
            this.Property(t => t.Designation)
                .IsRequired();
            this.Property(t => t.Date_creation);
                
            this.Property(t => t.date_Modification);
            this.Property(t => t.Departement_Id);
                


            // Table & Column Mappings
            this.ToTable("Atelier");

           

        }
    }
}
