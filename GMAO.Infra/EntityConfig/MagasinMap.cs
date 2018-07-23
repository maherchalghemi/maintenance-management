using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class MagasinMap : EntityTypeConfiguration<Magasin>
    {
        public MagasinMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Code_magasin)
                .IsRequired();
            this.Property(t => t.libelle)
                .IsRequired();
            this.Property(t => t.Adresse);
            this.Property(t => t.tel);
            this.Property(t => t.obsrvation);





            // Table & Column Mappings
            this.ToTable("Magasin");



        }
    }
}
