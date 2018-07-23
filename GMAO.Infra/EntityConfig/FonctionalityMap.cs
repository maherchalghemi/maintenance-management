using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class FonctionalityMap : EntityTypeConfiguration<Fonctionality>
    {
        public FonctionalityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nom)
                .IsRequired();
            this.Property(t => t.Categorie)
           .IsRequired();
            this.Property(t => t.IsMenu)
           .IsRequired();
            this.Property(t => t.Controler)
           .IsRequired();
            this.Property(t => t.Action)
           .IsRequired();
            this.Property(t => t.JavaAction)
            .IsRequired();
            this.Property(t => t.Icon)
           .IsRequired();
            this.Property(t => t.Module_Id)
           .IsRequired();
            this.Property(t => t.Group)
            .IsRequired();






            // Table & Column Mappings
            this.ToTable("Fonctionality");



        }
    }
}
