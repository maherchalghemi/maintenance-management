using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class ListeconsMaintEquipementMap : EntityTypeConfiguration<ListeconsMaintEquipement>
    {
        public ListeconsMaintEquipementMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired();
            this.Property(t => t.libellé)
           .IsRequired();

            this.Property(t => t.Designation)
            .IsRequired();
            this.Property(t => t.Cod_doc)
           .IsRequired();
            this.Property(t => t.Date_creation)
            .IsRequired();
            this.Property(t => t.date_Modification)
           .IsRequired();
            this.Property(t => t.niveau)
            .IsRequired();
            this.Property(t => t.Duree_Standard_JR)
           .IsRequired();
            this.Property(t => t.Duree_Standard_hhmm)
            .IsRequired();
            this.Property(t => t.photo)
           .IsRequired();
            this.Property(t => t.Nb_interv_suggéré)
            .IsRequired();
            this.Property(t => t.fréquence)
           .IsRequired();
            this.Property(t => t.NumEquipement)
            .IsRequired();
            this.Property(t => t.date_fin)
           .IsRequired();
            this.Property(t => t.date_début)
            .IsRequired();
            this.Property(t => t.STime)
           .IsRequired();
            this.Property(t => t.ETime)
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
            this.ToTable("ListeconsMaintEquipement");

            //relationShips
            this.HasRequired(t => t.equipement)
                    .WithMany(t => t.listconsMaintEquipement)
                    .HasForeignKey(t => t.Equipements_Id)
                    .WillCascadeOnDelete(true);





        }
    }
}
