using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class StockInMap : EntityTypeConfiguration<StockIn>
    {
        public StockInMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Ref);
            this.Property(t => t.personnel);
            this.Property(t => t.Date);
            this.Property(t => t.magasin);
            this.Property(t => t.piece);
            this.Property(t => t.observation);
            this.Property(t => t.refExt);
            this.Property(t => t.qte);
            this.Property(t => t.prix);
            this.Property(t => t.fournisseur);
            this.Property(t => t.emplacement);





            // Table & Column Mappings
            this.ToTable("StockIn");



        }
    }
}
