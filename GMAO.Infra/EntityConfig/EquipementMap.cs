using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class EquipementMap : EntityTypeConfiguration<Equipement>
    {
        public EquipementMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CodeEquipement)
                .IsRequired();
            this.Property(t => t.Designation)
           .IsRequired();
            this.Property(t => t.Description);
          
            this.Property(t => t.NumEquipement);
          
            this.Property(t => t.NumModel);
           

            this.Property(t => t.NumSerie);

            this.Property(t => t.Marque);
           
            this.Property(t => t.Code_poste);
          
            this.Property(t => t.Code_categorie);
           
            this.Property(t => t.codeclient);
           

            this.Property(t => t.EtatEquipement);
            
            this.Property(t => t.nb_eq);
           
            this.Property(t => t.Nature_Heure_Travail);
           
            this.Property(t => t.Photo);
           
            this.Property(t => t.Date_creation);
           
            this.Property(t => t.date_Modification);
           




            // Table & Column Mappings
            this.ToTable("Equipement");

           





        }
    }
}
