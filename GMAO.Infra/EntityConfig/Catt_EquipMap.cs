using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class Catt_EquipMap : EntityTypeConfiguration<Catt_Equip>
    {
        public Catt_EquipMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Code_cause)
                .IsRequired();
            this.Property(t => t.libelle)
                .IsRequired();
            this.Property(t => t.Date_creation)
               ;
            this.Property(t => t.date_Modification)
                ;
            this.Property(t => t.taux_horaire)
                ;
            this.Property(t => t.panne)
               ;




            // Table & Column Mappings
            this.ToTable("Catt_Equip");



        }
    }

}
