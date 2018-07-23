using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class Poste_de_chargeMap : EntityTypeConfiguration<Poste_de_charge>
    {
        public Poste_de_chargeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.dureeJr);
            
            this.Property(t => t.code_poste)
            .IsRequired();
            this.Property(t => t.NbEquipe);
           
            this.Property(t => t.Atelier);
            this.Property(t => t.Designation)
            .IsRequired();
            this.Property(t => t.Date_creation);

            this.Property(t => t.date_Modification);
            






            // Table & Column Mappings
            this.ToTable("Poste_de_charge");

            



        }
    }
}
