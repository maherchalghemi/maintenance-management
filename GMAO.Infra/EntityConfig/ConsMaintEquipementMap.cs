using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class ConsMaintEquipementMap : EntityTypeConfiguration<ConsMaintEquipement>
    {
        public ConsMaintEquipementMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.fréquence)
                .IsRequired();
            this.Property(t => t.NumEquipement)
           .IsRequired();
            this.Property(t => t.date_fin)
           .IsRequired();
            this.Property(t => t.date_début)
           .IsRequired();
            this.Property(t => t.alerte)
           .IsRequired();
            this.Property(t => t.Duré_cons_h)
            .IsRequired();
            this.Property(t => t.Code_Consigne)
           .IsRequired();
            this.Property(t => t.type)
           .IsRequired();
            this.Property(t => t.CodeCompt)
            .IsRequired();
            this.Property(t => t.periodicite)
           .IsRequired();
            this.Property(t => t.indice_gen)
           .IsRequired();
            this.Property(t => t.Duré_cons_jr)
            .IsRequired();
            this.Property(t => t.tYpe_planning)
           .IsRequired();
            this.Property(t => t.Départ_Compt)
            .IsRequired();





            // Table & Column Mappings
            this.ToTable("ConsMaintEquipement");



        }
    }
}
