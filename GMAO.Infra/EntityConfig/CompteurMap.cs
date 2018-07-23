using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class CompteurMap : EntityTypeConfiguration<Compteur>
    {
        public CompteurMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.codeCompt)
                .IsRequired();
            this.Property(t => t.unite);
           
            this.Property(t => t.valeur_compteur_max);
           
            this.Property(t => t.Date_creation);

            this.Property(t => t.date_Modification);
           





            // Table & Column Mappings
            this.ToTable("Compteur");



        }
    }
}
