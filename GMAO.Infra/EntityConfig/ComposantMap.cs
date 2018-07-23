using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.EntityConfig
{
    public class ComposantMap : EntityTypeConfiguration<Composant>
    {
        public ComposantMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.codeComposant)
                .IsRequired();

            this.Property(t => t.libelle);
            this.Property(t => t.NumLot);
            this.Property(t => t.codeBarre);
            this.Property(t => t.Date_reception);
            this.Property(t => t.delaiObtention);
            this.Property(t => t.NbrExemplaire);







            // Table & Column Mappings
            this.ToTable("Composant");



        }
    }
}
