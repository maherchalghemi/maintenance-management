using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class DepartementMap : EntityTypeConfiguration<Departement>
    {
        public DepartementMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.NumDepartement)
                .IsRequired();
            this.Property(t => t.Designation)
           .IsRequired();
            this.Property(t => t.Description);
           
            this.Property(t => t.Date_creation);

            this.Property(t => t.date_Modification);
           




            // Table & Column Mappings
            this.ToTable("Departement");

            




        }
    }
}
