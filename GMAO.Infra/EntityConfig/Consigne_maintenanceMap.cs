using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class Consigne_maintenanceMap : EntityTypeConfiguration<Consigne_maintenance>
    {
        public Consigne_maintenanceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                ;
           

            this.Property(t => t.Designation)
                .IsRequired();
            this.Property(t => t.Cod_doc)
            ;
            this.Property(t => t.Date_creation)
                ;
            this.Property(t => t.date_Modification)
                ;
            this.Property(t => t.niveau)
           ;
            
            this.Property(t => t.photo)
                ;
            this.Property(t => t.Nb_interv_suggéré)
                ;
            
            this.Property(t => t.Duré_cons_h)
            ;
            this.Property(t => t.Code_Consigne)
            .IsRequired();
            
            
            
            this.Property(t => t.Duré_cons_jr)
            ;
           
           



            // Table & Column Mappings
            this.ToTable("Consigne_maintenance");

            
        }
    }
}
