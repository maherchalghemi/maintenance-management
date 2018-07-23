using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class ArticleMap : EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Designation)
                .IsRequired();
            this.Property(t => t.Nature)
                .IsRequired();
            this.Property(t => t.PrixRevient)
                .IsRequired();
            this.Property(t => t.IDFamille)
                .IsRequired();
            this.Property(t => t.CractTechnique)
                .IsRequired();
            this.Property(t => t.IDSite)
                .IsRequired();
            this.Property(t => t.IDSociete)
                .IsRequired();
            this.Property(t => t.Reference)
                .IsRequired();


            // Table & Column Mappings
            this.ToTable("Article");

            //relationShips
            this.HasRequired(t => t.company)
                    .WithMany(t => t.articles)
                    .HasForeignKey(t => t.Company_Id)
                    .WillCascadeOnDelete(true);

        }
    }
}
