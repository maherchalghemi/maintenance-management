using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.EntityConfig
{
    public class DocumentMap : EntityTypeConfiguration<Document>
    {
        public DocumentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.codeDocument)
                .IsRequired();
            this.Property(t => t.libelle)
                .IsRequired();
            this.Property(t => t.typeDocument);
            this.Property(t => t.Edition);
            this.Property(t => t.Date_creation);
            this.Property(t => t.lien);









            // Table & Column Mappings
            this.ToTable("Document");



        }
    }
}
