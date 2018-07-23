using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class Dec_PanneMap : EntityTypeConfiguration<Dec_Panne>
    {
        public Dec_PanneMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Reference)
                .IsRequired();
            this.Property(t => t.Heure_Dec_Panne)
           .IsRequired();
            this.Property(t => t.Date_Dec_Panne)
           .IsRequired();
            this.Property(t => t.Heure_Arr_Panne)
           .IsRequired();
            this.Property(t => t.Date_Arr_Panne)
           .IsRequired();
            this.Property(t => t.Symtome)
            .IsRequired();
            this.Property(t => t.Action_Imediate)
           .IsRequired();
            this.Property(t => t.Diagnostic)
           .IsRequired();



            // Table & Column Mappings
            this.ToTable("Dec_Panne");

            //relationShips
            this.HasRequired(t => t.equipement)
                    .WithMany(t => t.dec_Pannes)
                    .HasForeignKey(t => t.Id_Equipement)
                    .WillCascadeOnDelete(true);

            this.HasRequired(t => t.personnel)
                    .WithMany(t => t.dec_Pannes)
                    .HasForeignKey(t => t.Id_Personnel)
                    .WillCascadeOnDelete(true);



        }
    }
}
